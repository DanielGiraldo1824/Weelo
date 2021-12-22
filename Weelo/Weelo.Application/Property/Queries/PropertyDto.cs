using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property.Queries
{
    public class PropertyDto
    {
        public PropertyDto()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public double Price { get; set; }

        public int CodeInternal { get; set; }

        public int Year { get; set; }

        public Guid IdOwner { get; set; }
    }
}
