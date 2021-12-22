using Weelo.Domain.Entities;
using Weelo.Domain.Exception;
using Weelo.Domain.Ports;
using Weelo.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Services
{
    [DomainService]
    public class PropertyImageService
    {
        readonly IGenericRepository<PropertyImage> _repository;
        public PropertyImageService(IGenericRepository<PropertyImage> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
        }

        public async Task<PropertyImage> RegisterPropertyImageAsync(PropertyImage propertyImage)
        {
            if (propertyImage != null)
            {
                return await _repository.AddAsync(propertyImage);
            }
            throw new PropertyException (MessageHandler.ERROR_IMAGE_PROPERTY);
        }

    }
}
