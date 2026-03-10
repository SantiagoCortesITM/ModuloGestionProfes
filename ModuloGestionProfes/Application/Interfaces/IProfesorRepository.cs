using ModuloGestionProfes.Domain.Entities;

namespace ModuloGestionProfes.Application.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllAsync();
        Task<Profesor> AddAsync(Profesor profesor);
        Task<bool> EmailExistsAsync(string email);
    }
}
