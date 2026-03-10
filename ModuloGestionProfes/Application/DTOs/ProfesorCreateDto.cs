using System.ComponentModel.DataAnnotations;

namespace ModuloGestionProfes.Application.DTOs
{
    public class ProfesorCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}