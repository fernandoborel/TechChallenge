using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Application.Dtos;

public class AtualizarContatoDto
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public int Ddd { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [Phone(ErrorMessage = "O campo {0} está em um formato inválido!")]
    public string Telefone { get; set; }
}