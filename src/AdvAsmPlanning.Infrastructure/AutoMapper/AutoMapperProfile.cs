namespace AdvAsmPlanning.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Forecast, ForecastDto>()
            .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

        CreateMap<ForecastActual, ForecastActualDto>();

        // Reverse maps for convenience
        CreateMap<ForecastDto, Forecast>()
            .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

        CreateMap<ForecastActualDto, ForecastActual>();

        // Planning Scenario mappings
        CreateMap<PlanningScenario, PlanningScenarioDto>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.LastUpdatedTime, opt => opt.MapFrom(src => src.UpdatedAt));

        CreateMap<PlanningScenarioDto, PlanningScenario>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedTime))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.LastUpdatedTime));
    }
}
