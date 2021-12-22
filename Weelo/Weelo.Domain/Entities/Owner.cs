using Weelo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Entities
{
    public class Owner : EntityBase<Guid>
    {
        [MaxLength(50)]
        public string Name { get; set; } = default!;
        [MaxLength(200)]
        public string Address { get; set; } = default!;
        public byte[] Photo { get; set; } = default!;
        public DateTime Birthday { get; set; }

        public Owner(string name, string address, byte[] photo, DateTime birthday)
        {
            Name = name;
            Address = address;
            Photo = photo;
           Birthday = birthday;
        }
        public Owner()
        {

        }
    }
}
