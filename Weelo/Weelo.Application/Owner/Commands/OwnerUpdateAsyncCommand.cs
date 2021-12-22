using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner.Commands
{

    public record OwnerUpdateAsyncCommand(
    [Required] Guid Id,
    [Required] string Name,
    [Required] string Address,
    [Required] byte[] Photo,
    [Required] DateTime? Birthday
) : IRequest;

}
