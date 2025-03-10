using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDR.Cadastro.Api.Controllers;

public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoService _departamentoService;

    public DepartamentoController(IDepartamentoService departamentoService) 
        => _departamentoService = departamentoService;

    [HttpGet("Departamento/{id}")]
    public async Task<DepartamentoDTO> GetDepartamento(Guid id)
        => await _departamentoService.RecuperarDepartamentoPorId(id);

    [HttpGet("Departamentos")]
    public async Task<IEnumerable<DepartamentoDTO>> GetDepatamentos()
        => await _departamentoService.RecuperarDepartamentos();

    [HttpPost("Adicionar")]
    public void AddDepartamento(DepartamentoDTO departamentoDTO)
        => _departamentoService.AdicionarDepartamento(departamentoDTO);
}
