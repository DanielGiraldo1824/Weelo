using Weelo.Domain.Entities;
using Weelo.Domain.Exception;
using Weelo.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Services
{
    [DomainService]
    public class PropertyTraceService
    {
        readonly IGenericRepository<PropertyTrace> _repository;
        public PropertyTraceService(IGenericRepository<PropertyTrace> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
        }

        public async Task<PropertyTrace> RegisterPropertyTraceAsync(PropertyTrace propertyTrace)
        {
            if (propertyTrace != null)
            {
                return await _repository.AddAsync(propertyTrace);
            }
            throw new PropertyException ("an error occurred registering the trace the property");
        }

    }
}
