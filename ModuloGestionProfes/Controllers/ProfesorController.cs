using Microsoft.AspNetCore.Mvc;
using ModuloGestionProfes.Application.DTOs;
using ModuloGestionProfes.Application.Interfaces;

namespace ModuloGestionProfes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profesores = await _profesorService.GetAllAsync();
            return Ok(profesores);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfesorCreateDto profesorCreateDto)
        {
            var profesorCreado = await _profesorService.AddAsync(profesorCreateDto);
            return Ok(profesorCreado);
        }
    }
}