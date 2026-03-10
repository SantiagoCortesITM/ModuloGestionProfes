using ModuloGestionProfes.Application.DTOs;

namespace ModuloGestionProfes.Application.Interfaces
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> GetAllAsync();
        Task<ProfesorDto> AddAsync(ProfesorCreateDto profesorCreateDto);
    }
}
