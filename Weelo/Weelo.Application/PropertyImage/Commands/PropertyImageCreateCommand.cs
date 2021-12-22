using MediatR;
using Weelo.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.PropertyImagen.Commands
{
    public record PropertyImageCreateCommand(
    [Required] Guid IdProperty,
    [Required] byte[] File,
    [Required] bool Enabled,
    [Required] string FileName
    ) : IRequest;

}