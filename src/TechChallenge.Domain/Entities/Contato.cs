using TechChallenge.Domain.Validations;
using FluentValidation.Results;

namespace TechChallenge.Domain.Entities;

public class Contato
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Ddd { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public ValidationResult Validate => new ContatoValidation().Validate(this);
}