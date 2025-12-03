namespace AdvAsmPlanning.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<MainGrid, MainGridDto>()
            .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

        CreateMap<MainGridActual, MainGridActualDto>();

        // Reverse maps for convenience
        CreateMap<MainGridDto, MainGrid>()
            .ForMember(dest => dest.Actuals, opt => opt.MapFrom(src => src.Actuals));

        CreateMap<MainGridActualDto, MainGridActual>();

        // Scenario mappings
        CreateMap<Scenario, ScenarioDto>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.LastUpdatedTime, opt => opt.MapFrom(src => src.UpdatedAt));

        CreateMap<ScenarioDto, Scenario>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedTime))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.LastUpdatedTime));
    }
}
