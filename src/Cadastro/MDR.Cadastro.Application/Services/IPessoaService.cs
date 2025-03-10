using MDR.Cadastro.Application.DTO;

namespace MDR.Cadastro.Application.Services;

public interface IPessoaService
{
    Task<IEnumerable<PessoaDTO>> RecuperarPessoas();
    Task<PessoaDTO> RecuperarPessoaPorId(Guid id);
    Task<IEnumerable<PessoaDTO>> RecuperarPessoaPorDepartamento(Guid id);
    void AdicionarPessoa(PessoaDTO pessoa);
    void EditarPessoa(PessoaDTO pessoa);

    
}
