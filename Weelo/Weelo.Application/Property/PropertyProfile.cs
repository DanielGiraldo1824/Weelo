using AutoMapper;
using Weelo.Application.Property.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Property
{
    public class PropertyImageProfile : Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<Weelo.Domain.Entities.Property, PropertyDto>().ReverseMap();
        }
    }
}
