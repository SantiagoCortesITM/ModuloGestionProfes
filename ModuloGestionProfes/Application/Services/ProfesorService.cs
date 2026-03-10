using AutoMapper;
using ModuloGestionProfes.Application.DTOs;
using ModuloGestionProfes.Application.Interfaces;
using ModuloGestionProfes.Domain.Entities;

namespace ModuloGestionProfes.Application.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _profesorRepository;
        private readonly IMapper _mapper;

        public ProfesorService(IProfesorRepository profesorRepository, IMapper mapper)
        {
            _profesorRepository = profesorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfesorDto>> GetAllAsync()
        {
            var profesores = await _profesorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProfesorDto>>(profesores);
        }

        public async Task<ProfesorDto> AddAsync(ProfesorCreateDto profesorCreateDto)
        {
            // Error intencional para probar middleware
            if (profesorCreateDto.Nombre.Trim().Equals("Error", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Error de prueba");
            }

            // Regla de negocio: especialidad no puede estar vacía
            if (string.IsNullOrWhiteSpace(profesorCreateDto.Especialidad))
            {
                throw new ApplicationException("La especialidad no puede estar vacía.");
            }

            // Log si es Arquitectura
            if (profesorCreateDto.Especialidad.Trim().Equals("Arquitectura", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Perfil Senior Detectado");
            }

            var profesor = _mapper.Map<Profesor>(profesorCreateDto);

            var profesorGuardado = await _profesorRepository.AddAsync(profesor);

            return _mapper.Map<ProfesorDto>(profesorGuardado);
        }
    }
}
