using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.CadastroDomain.Entities;
using MDR.CadastroDomain.Repositories;

namespace MDR.Cadastro.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public PessoaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void AdicionarPessoa(PessoaDTO pessoa)
    {
        Pessoa _pessoa = _mapper.Map<Pessoa>(pessoa);
        _unitOfWork.pessoaRepository.AdicionarPessoa(_pessoa);
        _unitOfWork.Commit();
    }

    public void EditarPessoa(PessoaDTO pessoa)
    {
        Pessoa _pessoa = _mapper.Map<Pessoa>(pessoa);
        _unitOfWork.pessoaRepository.EditarPessoa(_pessoa);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<PessoaDTO>> RecuperarPessoaPorDepartamento(Guid id)
        => _mapper.Map< IEnumerable<PessoaDTO>>(await _unitOfWork.pessoaRepository.RecuperarPessoaPorDepartamento(id));
    public async Task<PessoaDTO> RecuperarPessoaPorId(Guid id)
        => _mapper.Map<PessoaDTO>(await _unitOfWork.pessoaRepository.RecuperarPessoaPorId(id));
    public async Task<IEnumerable<PessoaDTO>> RecuperarPessoas()
        => _mapper.Map<IEnumerable<PessoaDTO>>(await _unitOfWork.pessoaRepository.RecuperarPessoas());
}
