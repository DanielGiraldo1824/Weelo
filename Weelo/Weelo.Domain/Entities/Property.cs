using Weelo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Entities
{
    public class Property : EntityBase<Guid>
    {
        [MaxLength(50)]
        public string Name { get; set; } = default!;

        [MaxLength(200)]
        public string Address { get; set; } = default!;

        public double Price { get; set; }

        public int CodeInternal { get; set; }

        public int Year { get; set; }

        public Guid IdOwner { get; set; }

        public Property(string name, string address, double price, int codeInternal, int year, Guid idOwner)
        {
            Name = name;
            Address = address;
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            IdOwner = idOwner;
        }

        public Property()
        {

        }

    }
}
