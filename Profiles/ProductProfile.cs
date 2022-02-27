using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportyApi.Helpers;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IServiceProvider service)
        {
            var root = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.GetRootPath();

            CreateMap<Product, ProductDto>()
                .ForMember(p => p.SportName, ps => ps.MapFrom(s => s.Sport.Name))
                .ForMember(p => p.ImageUrl, pi => pi.MapFrom(i => $"{root}{i.ImageUrl}"));
        }
    }
}
