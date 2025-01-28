using AutoMapper;
using TechChallenge.Application.Dtos;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Application.Services;

public class ContatoAppService : IContatoAppService
{
    private readonly IContatoDomainService _contatoDomainService;
    private readonly IMapper _mapper;

    public ContatoAppService(IContatoDomainService contatoDomainService, IMapper mapper)
    {
        _contatoDomainService = contatoDomainService;
        _mapper = mapper;
    }

    public void AtualizarContato(AtualizarContatoDto dto)
    {
        var contato = _mapper.Map<Contato>(dto);
        _contatoDomainService.AtualizarContato(contato);
    }

    public void CriarContato(CriarContatoDto dto)
    {
        var contato = _mapper.Map<Contato>(dto);
        _contatoDomainService.CriarContato(contato);
    }

    public void DeletarContato(RemoverContatoDto dto)
    {
        var contato = _mapper.Map<Contato>(dto);
        _contatoDomainService.DeletarContato(contato);
    }

    public void Dispose()
        => _contatoDomainService.Dispose();

    public Contato ObterContato(int id)
        => _contatoDomainService.ObterContatoPorId(id);

    public List<Contato> ObterContatos()
        => _contatoDomainService.ObterContatos();
}