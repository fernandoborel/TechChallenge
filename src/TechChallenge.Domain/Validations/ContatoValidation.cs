using FluentValidation;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Validations;

public class ContatoValidation : AbstractValidator<Contato>
{
    public ContatoValidation()
    {
        RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id é obrigatório");
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");
        RuleFor(x => x.Ddd)
            .NotEmpty()
            .WithMessage("Ddd é obrigatório")
            .Matches(@"^\d{2}$")
            .WithMessage("Ddd inválido");
        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório")
            .Matches(@"^\d{8,9}$")
            .WithMessage("Telefone inválido");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email é obrigatório");
    }
}