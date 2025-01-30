using TechChallenge.Domain.Entities;
using FluentAssertions;

namespace TechChallenge.UnitTests.Entities;

public class ContatoTest
{
    [Fact]
    public void ValidarIdTest()
    {
        var contato = new Contato
        {
            Id = 0,
        };

        contato.Validate
            .Errors
            .FirstOrDefault(x => x.ErrorMessage.Contains("Id é obrigatório"))
            .Should()
            .NotBeNull();
    }


    [Fact]
    public void ValidarNomeTest()
    {
        var contato = new Contato
        {
            Nome = string.Empty,
        };

        contato.Validate
            .Errors
            .FirstOrDefault(x => x.ErrorMessage.Contains("Nome é obrigatório"))
            .Should()
            .NotBeNull();
    }


    [Fact]
    public void ValidarEmailTest()
    {
        var contato = new Contato
        {
            Email = string.Empty
        };

        contato.Validate
            .Errors
            .FirstOrDefault(x => x.ErrorMessage.Contains("Email é obrigatório"))
            .Should()
            .NotBeNull();
    }


    [Fact]
    public void ValidarDddTest()
    {
        var contato = new Contato
        {
            Ddd = string.Empty,
        };
        contato.Validate
            .Errors
            .FirstOrDefault(x => x.ErrorMessage
            .Contains("Ddd inválido"))
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void ValidarTelefoneTest()
    {
        var contato = new Contato
        {
            Telefone = string.Empty,
        };
        contato.Validate
            .Errors
            .FirstOrDefault(x => x.ErrorMessage
            .Contains("Telefone inválido"))
            .Should()
            .NotBeNull();
    }
}