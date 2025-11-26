using Application.DTOs;
using AutoMapper;
using Objects.Entities;

namespace Infrastructure.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        internal AutoMapperProfile()
        {
            CreateMap<Sale, SaleDto>();
        }
    }
}
