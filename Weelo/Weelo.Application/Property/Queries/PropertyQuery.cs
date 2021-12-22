using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Queries
{
    public record PropertyQuery(string? Address, string? Name, int? InternalCode, string? OwnerName) : IRequest<IEnumerable<PropertyDto>>;
}
