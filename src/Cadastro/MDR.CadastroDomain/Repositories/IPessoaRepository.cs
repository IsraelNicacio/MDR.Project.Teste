using MDR.CadastroDomain.Entities;
using MDR.Core.Data;

namespace MDR.CadastroDomain.Repositories;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<IEnumerable<Pessoa>> RecuperarPessoas();
    Task<Pessoa> RecuperarPessoaPorId(Guid id);
    Task<IEnumerable<Pessoa>> RecuperarPessoaPorDepartamento(Guid id);
    void AdicionarPessoa(Pessoa pessoa);
    void EditarPessoa(Pessoa pessoa);

    Task<IEnumerable<Departamento>> RecuperarDepartamentos(Guid id);
    void AdicionarDepartamento(Departamento departamento);
    void EditarDepartamento(Departamento departamento);
}
