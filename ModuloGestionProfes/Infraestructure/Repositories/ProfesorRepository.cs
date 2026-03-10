using Microsoft.EntityFrameworkCore;
using ModuloGestionProfes.Application.Interfaces;
using ModuloGestionProfes.Domain.Entities;
using ModuloGestionProfes.Infrastructure.Data;

namespace ModuloGestionProfes.Infrastructure.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly AppDbContext _context;

        public ProfesorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesor> AddAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
            return profesor;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Profesores.AnyAsync(p => p.Email == email);
        }
    }
}
