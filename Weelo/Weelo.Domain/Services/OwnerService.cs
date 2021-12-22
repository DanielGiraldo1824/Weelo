using Weelo.Domain.Entities;
using Weelo.Domain.Exception;
using Weelo.Domain.Ports;

namespace Weelo.Domain.Services
{

    [DomainService]
    public class OwnerService
    {
        readonly IGenericRepository<Owner> _repository;
        public OwnerService(IGenericRepository<Owner> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
        }

        public async Task<Owner> RegisterOwnerAsync(Owner owner)
        {
            if (owner != null)
            {
                return await _repository.AddAsync(owner);
            }
            throw new OwnerException("an error occurred registering the owner");
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
                if (owner != null)
                {
                     await _repository.UpdateAsync(owner);
                }   
        }
    }
}
