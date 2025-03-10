using MDR.CadastroDomain.Repositories;
using MDR.Infrastructure.Data.Context;

namespace MDR.Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CadastroContext _context;

    private IPessoaRepository _pessoaRepository;
    public IPessoaRepository pessoaRepository 
    { get => _pessoaRepository ?? (_pessoaRepository = new PessoaRepository(_context)); }

    public UnitOfWork(CadastroContext context) 
        => _context = context;

    public bool Commit() => _context.SaveChanges() > 0;

    public void Dispose() => _context.Dispose();
}
