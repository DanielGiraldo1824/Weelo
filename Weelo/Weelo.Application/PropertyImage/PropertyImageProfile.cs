using AutoMapper;
using Weelo.Application.Property.Queries;
using Weelo.Application.PropertyImage.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.PropertyImage
{
    public class PropertyImageProfile : Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<Weelo.Domain.Entities.PropertyImage, PropertyImageDto>().ReverseMap();
        }
    }
}
