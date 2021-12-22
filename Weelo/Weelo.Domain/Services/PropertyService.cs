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
    public class PropertyService
    {
        readonly IGenericRepository<Property> _repository;
        public PropertyService(IGenericRepository<Property> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
        }

        public async Task<Property> RegisterPropertyAsync(Property property)
        {
            if (property != null)
            {
                return await _repository.AddAsync(property);
            }
            throw new PropertyException (MessageHandler.ERROR_PROPERTY);
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            if (property != null)
            {
                await _repository.UpdateAsync(property);
            }
        }

        public async Task GetPropertybyIntrnalCodeAsync(int code)
        {
            if (code > 0)
            {
                var property = await _repository.GetAsync(findProperty => findProperty.CodeInternal == code).ConfigureAwait(false);
                if (property.FirstOrDefault() != null)
                {
                    throw new PropertyException(MessageHandler.PROPERTY_DUPLICATED);
                }
            }
        }
    }
}
