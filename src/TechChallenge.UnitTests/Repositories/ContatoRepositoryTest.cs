using Bogus;
using FluentAssertions;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repositories;

namespace TechChallenge.UnitTests.Repositories;

public class ContatoRepositoryTest
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoRepositoryTest(IContatoRepository contatoRepository)
      => _contatoRepository = contatoRepository;

    [Fact]
    public void TestCreate()
    {
        #region Cadastrando contato

        var contato = CreateContato();

        #endregion

        #region Verificando se foi cadastrado

        var contatoById = _contatoRepository.GetById(contato.Id);
        contatoById.Should().NotBeNull();
        contatoById.Nome.Should().Be(contato.Nome);
        contatoById.Email.Should().Be(contato.Email);

        #endregion
    }

    [Fact]
    public void TestUpdate()
    {
        #region Cadastrando contato

        var contato = CreateContato();

        #endregion

        #region Atualização do contato

        var faker = new Faker("pt_BR");
        
        contato.Nome = faker.Person.FullName;
        contato.Email = faker.Person.Email;
        contato.Ddd = faker.Person.Phone.Substring(1, 2);
        contato.Telefone = faker.Person.Phone;

        _contatoRepository.Update(contato);

        #endregion

        #region Verificando se foi cadastrado

        var contatoById = _contatoRepository.GetById(contato.Id);

        contatoById.Should().NotBeNull();
        contatoById.Nome.Should().Be(contato.Nome);
        contatoById.Email.Should().Be(contato.Email);

        #endregion
    }

    [Fact]
    public void TestDelete()
    {
        #region Cadastrando contato
        
        var contato = CreateContato();
        
        #endregion
        
        #region Deletando contato
        
        _contatoRepository.Delete(contato);
        
        #endregion
        
        #region Verificando se foi deletado
        
        var contatoById = _contatoRepository.GetById(contato.Id);
        contatoById.Should().BeNull();
        
        #endregion
    }

    [Fact]
    public void TestGetAll()
    {
        #region Cadastrando contato
        
        var contato = CreateContato();
        
        #endregion
        
        #region Consultando todos os usuários
        
        var lista = _contatoRepository.GetAll();

        #endregion

        #region Verificando se foi cadastrado

        lista.FirstOrDefault(x => x.Id.Equals(contato.Id)).Should().NotBeNull();

        #endregion
    }

    [Fact]
    public void TestGetById()
    {
        #region Cadastrando contato

        var contato = CreateContato();

        #endregion

        #region Consultando contato por Id

        var contatoById = _contatoRepository.GetById(contato.Id);

        #endregion

        #region Verificando se foi cadastrado

        contatoById.Should().NotBeNull();
        contatoById.Nome.Should().Be(contatoById.Nome);
        contatoById.Email.Should().Be(contatoById.Email);

        #endregion
    }

    private Contato CreateContato()
    {
        var faker = new Faker("pt_BR");
        var contato = new Contato
        {
            Nome = faker.Person.FullName,
            Email = faker.Person.Email,
            Ddd = faker.Person.Phone.Substring(1, 2),
            Telefone = faker.Person.Phone
        };

        _contatoRepository.Create(contato);
        return contato;
    }
}