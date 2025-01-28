using TechChallenge.Application.Dtos;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces;

public interface IContatoAppService : IDisposable
{
    void CriarContato(CriarContatoDto dto);
    void AtualizarContato(AtualizarContatoDto dto);
    void DeletarContato(RemoverContatoDto dto);
    Contato ObterContato(int id);
    List<Contato> ObterContatos();
}