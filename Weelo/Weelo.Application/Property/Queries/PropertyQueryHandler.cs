using AutoMapper;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Queries
{
    public class PropertyQueryHandler : IRequestHandler<PropertyQuery, IEnumerable<PropertyDto>>
    {

        private readonly IDbConnection _dapperSource;
        private readonly IMapper _mapper;

        public PropertyQueryHandler(IDbConnection dapperSource, IMapper mapper)
        {
            _dapperSource = dapperSource ?? throw new ArgumentNullException(nameof(dapperSource));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PropertyDto>> Handle(PropertyQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            var sql = $"SELECT p.* FROM [weelo].[Property] AS p INNER JOIN [weelo].[Owner] As o ON p.IdOwner = o.Id WHERE 1=1 ";

            if (!string.IsNullOrEmpty(request.Name))
                sql += $" AND LOWER(p.Name) like LOWER('%{request.Name}%') ";

            if (!string.IsNullOrEmpty(request.Address))
                sql += $"AND LOWER(Address) like LOWER('%{request.Address}%') ";

            if (!string.IsNullOrEmpty(request.OwnerName))
                sql += $"AND LOWER(o.Name) like LOWER('%{request.OwnerName}%') ";

            if (request.InternalCode > 0)
                sql += $"AND p.CodeInternal = {request.InternalCode}";

            var propertyInfo = _dapperSource.QueryMultiple(sql);
            return _mapper.Map<IEnumerable<PropertyDto>>(propertyInfo.Read<Weelo.Domain.Entities.Property>());
        }


    }
}
