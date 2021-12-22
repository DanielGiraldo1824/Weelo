using Weelo.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Queries
{
    public class PropertyResponse
    {
        public PropertyResponse()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public double Price { get; set; }

        public int CodeInternal { get; set; }

        public int Year { get; set; }

        public OwnerDto Owner { get; set; }
    }
}
