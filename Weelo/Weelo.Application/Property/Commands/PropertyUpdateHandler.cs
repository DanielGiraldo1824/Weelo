using MediatR;
using Weelo.Application.Resources;
using Weelo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Commands
{

    public class PropertyUpdateHandler : AsyncRequestHandler<PropertyUpdateCommand>
    {
        private readonly PropertyService _PersonService;
        private readonly OwnerService _OwnerService;
        public PropertyUpdateHandler(PropertyService personService, OwnerService ownerService)
        {
            _PersonService = personService ?? throw new ArgumentNullException(nameof(personService));
            _OwnerService = ownerService ?? throw new ArgumentNullException(nameof(ownerService));
        }

        protected override async Task Handle(PropertyUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

                await _OwnerService.UpdateOwnerAsync(
                    new Weelo.Domain.Entities.Owner
                    {
                        Id = request.Owner.Id,
                        Address = request.Owner.Address,
                        Name = request.Owner.Name,
                        Photo = Convert.FromBase64String(request.Owner.Photo),
                        Birthday = request.Owner.Birthday
                    }
                 );

                await _PersonService.UpdatePropertyAsync(
                     new Weelo.Domain.Entities.Property
                     {
                         Id = request.Id,
                         Name = request.Name,
                         Address = request.Address,
                         Price = request.Price,
                         Year = request.Year,
                         CodeInternal = request.CodeInternal,
                         IdOwner = request.Owner.Id
                     }
                 );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


        }

    }
}
