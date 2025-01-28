using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Application.Dtos;

public class RemoverContatoDto
{
    [Required]
    public int Id { get; set; }
}