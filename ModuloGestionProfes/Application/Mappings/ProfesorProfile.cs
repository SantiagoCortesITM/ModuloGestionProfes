using AutoMapper;
using ModuloGestionProfes.Application.DTOs;
using ModuloGestionProfes.Domain.Entities;

namespace ModuloGestionProfes.Application.Mappings
{
    public class ProfesorProfile : Profile
    {
        public ProfesorProfile()
        {
            CreateMap<Profesor, ProfesorDto>();

            CreateMap<ProfesorCreateDto, Profesor>()
                .ForMember(dest => dest.FechaContratacion,
                    opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
