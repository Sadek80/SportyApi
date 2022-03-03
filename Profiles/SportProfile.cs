using AutoMapper;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Profiles
{
    public class SportProfile : Profile
    {
        public SportProfile()
        {
            CreateMap<Sport, SportBaseDto>();
        }
    }
}
