using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repositories;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Domain.Services;

public class ContatoDomainService : IContatoDomainService
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoDomainService(IContatoRepository contatoRepository)
      =>  _contatoRepository = contatoRepository;

    public void AtualizarContato(Contato contato)
        => _contatoRepository.Update(contato);

    public void CriarContato(Contato contato)
        => _contatoRepository.Create(contato);

    public void DeletarContato(Contato contato)
        =>  _contatoRepository.Delete(contato);

    public void Dispose()
        => _contatoRepository.Dispose();

    public Contato ObterContatoPorId(int id)
    {
        var contato = _contatoRepository.GetById(id);
        if (contato is null)
            throw new Exception("Contato não encontrado");

        return contato;
    }

    public List<Contato> ObterContatos()
        => _contatoRepository.GetAll();
}