using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoAppService _contatoAppService;

    public ContatoController(IContatoAppService contatoAppService)
     => _contatoAppService = contatoAppService;

    [HttpGet("ListarContatos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        var contatos = _contatoAppService.ObterContatos();
        if (contatos != null && contatos.Any())
            return StatusCode(200, new { message = "Contato(s) encontrado(s)", quantidade = contatos.Count(), contatos });

        return StatusCode(500, new { message = "Nenhum contato encontrado" });
    }
}