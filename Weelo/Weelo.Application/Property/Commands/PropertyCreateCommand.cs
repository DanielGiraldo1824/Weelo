using MediatR;
using Weelo.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Commands
{
    public record PropertyCreateCommand(
    [Required] string Name,
    [Required] string Address,
     [Required] double Price,
    [Required] int CodeInternal,
    [Required] int Year,
    [Required] OwnerDto Owner
) : IRequest;

}
