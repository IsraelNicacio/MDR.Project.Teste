namespace MDR.CadastroDomain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IPessoaRepository pessoaRepository { get; }
    bool Commit();
}
