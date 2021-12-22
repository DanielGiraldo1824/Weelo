using MediatR;
using Weelo.Application.PropertyImagen.Commands;
using Weelo.Application.Resources;
using Weelo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.PropertyImage.Commands
{

    public class PropertyImageCreateHandler : AsyncRequestHandler<PropertyImageCreateCommand>
    {
        private readonly PropertyImageService _PropertyImageService;
        public PropertyImageCreateHandler(PropertyImageService propertyImageService)
        {
            _PropertyImageService = propertyImageService ?? throw new ArgumentNullException(nameof(propertyImageService));
        }

        protected override async Task Handle(PropertyImageCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await _PropertyImageService.RegisterPropertyImageAsync(
                     new Weelo.Domain.Entities.PropertyImage
                     {
                         Id = Guid.NewGuid(),
                         IdProperty = request.IdProperty,
                         File = request.File,
                         Enabled = request.Enabled,
                         FileName = request.FileName
                     }
                 );
            }
        }
}
