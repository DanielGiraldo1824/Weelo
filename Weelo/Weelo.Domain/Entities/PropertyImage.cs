using Weelo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Entities
{
    public class PropertyImage : EntityBase<Guid>
    {
        public Guid IdProperty { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; } = default!;

        public byte[] File { get; set; }

        public bool Enabled { get; set; }

        public PropertyImage(Guid idProperty, byte[] file, bool enabled)
        {
            IdProperty = idProperty;
            File = file;
            Enabled = enabled;
        }

        public PropertyImage()
        {

        }
    }
}
