using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDR.Cadastro.Api.Controllers;

[ApiController]
[Route("{tenant}/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessooaService;

    public PessoaController(IPessoaService pessooaService)
        => _pessooaService = pessooaService;

    [HttpGet("Pessoa/{id}")]
    public async Task<PessoaDTO> GetPessoa(Guid id)
        => await _pessooaService.RecuperarPessoaPorId(id);

    [HttpGet("Pessoas")]
    public Task<IEnumerable<PessoaDTO>> GetPessoas()
        => _pessooaService.RecuperarPessoas();

    [HttpPost("Adicionar")]
    public void AddPessoa(PessoaDTO pessoaDTO)
        => _pessooaService.AdicionarPessoa(pessoaDTO);
}
