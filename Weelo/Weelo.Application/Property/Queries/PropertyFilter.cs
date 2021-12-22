using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Queries
{
    public class PropertyFilter
    {

        public string? Name { get; set; } = default!;

        public string? Address { get; set; } = default!;

        public int? InternalCode { get; set; }

        public string? OwnerName { get; set; } = default!;

    }
}
