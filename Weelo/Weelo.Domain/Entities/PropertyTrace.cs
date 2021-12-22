using Weelo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Entities
{
    public class PropertyTrace : EntityBase<Guid>
    {
        public DateTime DateSale { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = default!;

        [MaxLength(400)]
        public string Value { get; set; } = default!;

        public double Tax { get; set; }

        public Guid IdProperty { get; set; }

        public PropertyTrace(DateTime dateSale, string name, string value, double tax, Guid idProperty)
        {
            DateSale = dateSale;
            Name = name;
            Value = value;
            Tax = tax;
            IdProperty = idProperty;
        }
    }
}
