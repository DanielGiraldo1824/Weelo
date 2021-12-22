using AutoMapper;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner.Queries
{
    public class OwnerQueryHandler : IRequestHandler<OwnerQuery, OwnerDto>
    {

        private readonly IDbConnection _dapperSource;
        private readonly IMapper _mapper;

        public OwnerQueryHandler(IDbConnection dapperSource, IMapper mapper)
        {
            _dapperSource = dapperSource ?? throw new ArgumentNullException(nameof(dapperSource));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OwnerDto> Handle(OwnerQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            var ownerInfo = await _dapperSource.QuerySingleOrDefaultAsync<Weelo.Domain.Entities.Owner>("select * from weelo.Owner where Id = @id", new { Id = request.Id });
            return _mapper.Map<OwnerDto>(ownerInfo);
        }


    }
}
