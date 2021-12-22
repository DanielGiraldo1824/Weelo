using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner.Queries
{
    public record OwnerQuery([Required] Guid Id) : IRequest<OwnerDto>;
}
