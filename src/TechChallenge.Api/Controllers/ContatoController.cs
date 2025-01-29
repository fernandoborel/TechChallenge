using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Dtos;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoAppService _contatoAppService;

    public ContatoController(IContatoAppService contatoAppService)
     => _contatoAppService = contatoAppService;

    #region GET

    [HttpGet("ListarContatos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        var contatos = _contatoAppService.ObterContatos();
        if (contatos != null && contatos.Any())
            return StatusCode(200, new { message = "Contato(s) encontrado(s)", quantidade = contatos.Count(), contatos });

        return StatusCode(500, new { message = "Nenhum contato encontrado" });
    }

    [HttpGet("ObterContato/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        var contato = _contatoAppService.ObterContato(id);
        if (contato != null)
            return StatusCode(200, new { message = "Contato encontrado", contato });
        return StatusCode(500, new { message = "Contato não encontrado" });
    }

    #endregion

    #region POST

    [HttpPost("CriarContato")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] CriarContatoDto dto)
    {
        _contatoAppService.CriarContato(dto);
        return StatusCode(201, new { message = "Contato criado com sucesso" });
    }

    #endregion

    #region PUT

    [HttpPut("AtualizarContato")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update([FromBody] AtualizarContatoDto dto)
    {
        _contatoAppService.AtualizarContato(dto);
        return StatusCode(200, new { message = "Contato atualizado com sucesso" });
    }

    #endregion

    #region DELETE

    [HttpDelete("DeletarContato")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete([FromBody] RemoverContatoDto dto)
    {
        _contatoAppService.DeletarContato(dto);
        return StatusCode(200, new { message = "Contato deletado com sucesso" });
    }

    #endregion
}