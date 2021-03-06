using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportyApi.Helpers;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Profiles
{
    public class TrainingProgramProfile : Profile
    {
        public TrainingProgramProfile(IServiceProvider service)
        {
            var root = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Request.GetRootPath();

            CreateMap<TrainingProgram, TrainingProgramDto>()
                .ForMember(t => t.SportName, ts => ts.MapFrom(s => s.Sport.Name))
                .ForMember(t => t.Level, tl => tl.MapFrom(l => l.Level.Description))
                .ForMember(t => t.ImageUrl, ti => ti.MapFrom(i => $"{root}{i.ImageUrl}"));

            CreateMap<TrainingProgram, TrainingProgramFullDto>()
                .ForMember(t => t.SportName, ts => ts.MapFrom(s => s.Sport.Name))
                .ForMember(t => t.Level, tl => tl.MapFrom(l => l.Level.Description))
                .ForMember(t => t.ImageUrl, ti => ti.MapFrom(i => $"{root}{i.ImageUrl}"));

            CreateMap<ReservedProgram, TrainingProgramHistoryDto>()
                .ForMember(t => t.Name, tn => tn.MapFrom(rtn => rtn.TrainingProgram.Name))
                .ForMember(t => t.SportName, ts => ts.MapFrom(rts => rts.TrainingProgram.Sport.Name))
                .ForMember(t => t.Level, tl => tl.MapFrom(rtl => rtl.TrainingProgram.Level.Description))
                .ForMember(t => t.DescriptionMinimized, rd => rd.MapFrom(rtd => rtd.TrainingProgram.DescriptionMinimized))
                .ForMember(t => t.ImageUrl, ti => ti.MapFrom(i => $"{root}{i.TrainingProgram.ImageUrl}"))
                .ForMember(t => t.PricePerMonth, ti => ti.MapFrom(i => i.TrainingProgram.PricePerMonth))
                .ForMember(t => t.Date, r => r.MapFrom(rd => rd.Date.GetDateFormatted()));

        }
    }
}
