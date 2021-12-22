using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner.Queries
{

    public class OwnerDto
    {
        public OwnerDto()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public String Photo { get; set; } = default!;

        public DateTime Birthday { get; set; }
    }
}
