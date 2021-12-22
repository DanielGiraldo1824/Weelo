using AutoMapper;
using Weelo.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Owner
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Weelo.Domain.Entities.Owner, OwnerDto>().ReverseMap();
        }
    }
}
