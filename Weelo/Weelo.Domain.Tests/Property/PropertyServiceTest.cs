using Weelo.Domain.Exception;
using Weelo.Domain.Ports;
using Weelo.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Weelo.Domain.Tests.Property
{
    [TestClass]
    public class PropertyServiceTest
    {

        IGenericRepository<Weelo.Domain.Entities.Property> _propertyRepository = default!;
        PropertyService _propertyService = default!;

        [TestInitialize]
        public void Init(){
            _propertyRepository = Substitute.For<IGenericRepository<Weelo.Domain.Entities.Property>>();
            _propertyService = new PropertyService(_propertyRepository);
        }

        [TestMethod]
        public async Task FailToRegisterAnUnderageProperty()
        {
            try
            {
                Domain.Entities.Property newborn = new()
                {
                    Name = "john",
                    Address = "Cra 434 # 2343",
                    CodeInternal = 345,
                    IdOwner = Guid.Parse("190BE6BC-66DA-4B20-E20D-08D9C4168C98"),
                    Price = 33000000,
                    Year = 2017 
                };
                await _propertyService.RegisterPropertyAsync(newborn);
            }catch(System.Exception ex){
                Assert.IsTrue(ex is PropertyException );
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterProperty()
        {
            Weelo.Domain.Entities.Property older = new()
            {
                Name = "john",
                Address = "Cra 434 # 2343",
                CodeInternal = 345,
                IdOwner = Guid.Parse("190BE6BC-66DA-4B20-E20D-08D9C4168C98"),
                Price = 33000000,
                Year = 2017
            };

            _propertyRepository.AddAsync(Arg.Any<Weelo.Domain.Entities.Property>()).Returns(Task.FromResult(
                new PropertyDataBuilder()
                    .WithName(older.Name)
                    .WithAddress(older.Address)
                    .WithInternalCode(older.CodeInternal)
                    .WithPrice(older.Price)
                    .WithYear(older.Year)
                    .WithOwner(older.IdOwner).Build()
            ));

            var result = await _propertyService.RegisterPropertyAsync(older);

            Assert.IsTrue(result is Weelo.Domain.Entities.Property && result?.Id is not null);
        }


        [TestMethod]
        public async Task SuccessPutProperty()
        {

            //Arrange
            int expected = 1;
            int counter = 0;

            Weelo.Domain.Entities.Property older = new()
            {
                Id = Guid.Parse("5E29AD77-5644-44B6-A29A-8E8C05A67C63"),
                Name = "john",
                Address = "Cra 434 # 2343",
                CodeInternal = 345,
                IdOwner = Guid.Parse("190BE6BC-66DA-4B20-E20D-08D9C4168C98"),
                Price = 33000000,
                Year = 2017
            };
            _propertyRepository.When(tss => tss.UpdateAsync(Arg.Any<Weelo.Domain.Entities.Property>())).Do(x => counter++);
            _propertyRepository.UpdateAsync(Arg.Any<Weelo.Domain.Entities.Property>()).Returns(Task.FromResult(
                new PropertyDataBuilder()
                    .WithName(older.Name)
                    .WithAddress(older.Address)
                    .WithInternalCode(older.CodeInternal)
                    .WithPrice(older.Price)
                    .WithYear(older.Year)
                    .WithOwner(older.IdOwner).Build()
            ));

            //Act
            await _propertyService.UpdatePropertyAsync(older);

            //Assert
            Assert.AreEqual(expected, counter);
        }

        [TestMethod]
        public async Task SuccessGetPropertyByInternalCode()
        {

            //Arrange
            int expected = 2;
            int counter = 0;
            int code = 5;

            Weelo.Domain.Entities.Property older = new()
            {
                Id = Guid.Parse("5E29AD77-5644-44B6-A29A-8E8C05A67C63"),
                Name = "john",
                Address = "Cra 434 # 2343",
                CodeInternal = 345,
                IdOwner = Guid.Parse("190BE6BC-66DA-4B20-E20D-08D9C4168C98"),
                Price = 33000000,
                Year = 2017
            };

            IEnumerable<Weelo.Domain.Entities.Property> propertyBuilder =
                new List<Weelo.Domain.Entities.Property>(){
                new PropertyDataBuilder()
                    .WithName(older.Name)
                    .WithAddress(older.Address)
                    .WithInternalCode(older.CodeInternal)
                    .WithPrice(older.Price)
                    .WithYear(older.Year)
                    .WithOwner(older.IdOwner).Build()
                };

            _propertyRepository.WhenForAnyArgs(tss =>  tss.GetAsync()).Do(x => counter++);
            _propertyRepository.GetAsync(findProperty => findProperty.CodeInternal == code).Returns(propertyBuilder);

            //Act
            await _propertyService.GetPropertybyIntrnalCodeAsync(code);

            //Assert
            Assert.AreEqual(expected, counter);
        }
    }
}
