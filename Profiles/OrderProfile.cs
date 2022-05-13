using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportyApi.Helpers;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.OrderDto;
using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Profiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile(IServiceProvider provider)
        {
            var root = provider.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.GetRootPath();

            CreateMap<OrderForCreationDto, Order>();
            CreateMap<CreditCardDto, OrderCreditCard>();
            CreateMap<OrderItemForCreationDto, OrderItem>();
            CreateMap<Order, OrderHistoryDto>()
                .ForMember(oh => oh.Date, o => o.MapFrom(od => od.Date.GetDateFormatted()));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(i => i.Name, oi => oi.MapFrom(ni => ni.Product.Name))
                .ForMember(i => i.ImageUrl, oi => oi.MapFrom(ni => $"{root}{ni.Product.ImageUrl}"));
            CreateMap<OrderCreditCard, CreditCardDto>();
            CreateMap<OrderHistoryDto, OrderHistoryMinimizedDto>();
        }
    }
}
