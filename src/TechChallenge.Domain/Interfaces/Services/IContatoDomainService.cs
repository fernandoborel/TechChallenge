using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Services;

public interface IContatoDomainService : IDisposable
{
    void CriarContato(Contato contato);
    void AtualizarContato(Contato contato);
    void DeletarContato(Contato contato);
    Contato ObterContatoPorId(int id);
    List<Contato> ObterContatos();
}