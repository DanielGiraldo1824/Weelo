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

    public class PropertyCreateHandler : AsyncRequestHandler<PropertyCreateCommand>
    {
        private readonly PropertyService _PropertyService;
        private readonly OwnerService _OwnerService;
        public PropertyCreateHandler(PropertyService propertyService, OwnerService ownerService)
        {
            _PropertyService = propertyService ?? throw new ArgumentNullException(nameof(propertyService));
            _OwnerService = ownerService ?? throw new ArgumentNullException(nameof(ownerService));
        }

        protected override async Task Handle(PropertyCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await _PropertyService.GetPropertybyIntrnalCodeAsync(request.CodeInternal);

            var owner = new Weelo.Domain.Entities.Owner
            {
                Id = Guid.NewGuid(),
                Address = request.Owner.Address,
                Name = request.Owner.Name,
                Photo = Convert.FromBase64String(request.Owner.Photo),
                Birthday = request.Owner.Birthday
            };
            await _OwnerService.RegisterOwnerAsync(owner);

            await _PropertyService.RegisterPropertyAsync(
                     new Weelo.Domain.Entities.Property
                     {
                         Name = request.Name,
                         Address = request.Address,
                         Price = request.Price,
                         Year = request.Year,
                         CodeInternal = request.CodeInternal,
                         IdOwner = owner.Id
                     }
                 );
            }
        }
}
