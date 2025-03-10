using MDR.CadastroDomain.Entities;
using MDR.CadastroDomain.Repositories;
using MDR.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MDR.Infrastructure.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly CadastroContext _context;

    public PessoaRepository(CadastroContext context) => _context = context;

    public async Task<IEnumerable<Pessoa>> RecuperarPessoas()
        => await _context.Pessoas.AsNoTracking().ToListAsync();
    public async Task<Pessoa> RecuperarPessoaPorId(Guid id) 
        => await _context.Pessoas.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
    public async Task<IEnumerable<Pessoa>> RecuperarPessoaPorDepartamento(Guid id)
        => await _context.Pessoas.AsNoTracking().Where(w => w.Departamento.Id == id).ToListAsync();
    public void AdicionarPessoa(Pessoa pessoa) 
        => _context.Pessoas.AddAsync(pessoa);
    public void EditarPessoa(Pessoa pessoa) 
        => _context.Update(pessoa);

    public void AdicionarDepartamento(Departamento departamento)
        => _context.Departamentos.Add(departamento);
    public void EditarDepartamento(Departamento departamento)
        => _context.Update(departamento);
    public void Dispose() => GC.SuppressFinalize(this);
    public async Task<IEnumerable<Departamento>> RecuperarDepartamentos()
        => await _context.Departamentos.AsNoTracking().ToListAsync();
    public async Task<Departamento> RecuperarDepartamentoPorId(Guid id)
        => await _context.Departamentos.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
}
