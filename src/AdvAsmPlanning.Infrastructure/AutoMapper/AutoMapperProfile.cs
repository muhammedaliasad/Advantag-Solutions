using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Entities;
using AutoMapper;

namespace AdvAsmPlanning.Infrastructure.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        internal AutoMapperProfile()
        {
            CreateMap<Forecast, ForecastDto>()
                .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

            CreateMap<ForecastActual, ForecastActualDto>();

            // Reverse maps for convenience
            CreateMap<ForecastDto, Forecast>()
                .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

            CreateMap<ForecastActualDto, ForecastActual>();
        }
    }
}
