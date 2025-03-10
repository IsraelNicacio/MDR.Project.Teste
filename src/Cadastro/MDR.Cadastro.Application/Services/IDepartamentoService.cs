using MDR.Cadastro.Application.DTO;

namespace MDR.Cadastro.Application.Services;

public interface IDepartamentoService
{
    Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos(Guid id);
    void AdicionarDepartamento(DepartamentoDTO departamento);
    void EditarDepartamento(DepartamentoDTO departamento);
}
