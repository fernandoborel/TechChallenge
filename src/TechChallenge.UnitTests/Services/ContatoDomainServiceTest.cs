using Bogus;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.UnitTests.Services;

public class ContatoDomainServiceTest
{
    private readonly IContatoDomainService _contatoDomainService;

    public ContatoDomainServiceTest(IContatoDomainService contatoDomainService)
      => _contatoDomainService = contatoDomainService;

    [Fact]
    public void TestCriarContato()
    {
        try
        {
            var contato = NewContato();
            _contatoDomainService.CriarContato(contato);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    private Contato NewContato()
    {
        var faker = new Faker();
        return new Contato
        {
            Nome = faker.Person.FullName,
            Email = faker.Person.Email,
            Ddd = faker.Person.Phone.Substring(1, 2),
            Telefone = faker.Person.Phone
        };
    }
}