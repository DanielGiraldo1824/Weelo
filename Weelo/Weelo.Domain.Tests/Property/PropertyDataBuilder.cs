using System;
using Weelo.Domain.Entities;

namespace Weelo.Domain.Tests.Property
{
    public class PropertyDataBuilder
    {
        string Name = default!;
        string Address = default!;
        int CodeInternal = default!;
        int Year = default!;
        double Price = default!;
        Guid IdOwner;

        public Domain.Entities.Property Build()
        {
            Domain.Entities.Property property = new(Name, Address, Price, CodeInternal, Year, IdOwner); 
            return property;
        }

        public PropertyDataBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public PropertyDataBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }

        public PropertyDataBuilder WithInternalCode(int code)
        {
            CodeInternal = code;
            return this;
        }

        public PropertyDataBuilder WithYear(int year)
        {
            Year = year;
            return this;
        }

        public PropertyDataBuilder WithPrice(double price)
        {
            Price = price;
            return this;
        }

        public PropertyDataBuilder WithOwner(Guid idOwner)
        {
            IdOwner = idOwner;
            return this;
        }
    }
}
