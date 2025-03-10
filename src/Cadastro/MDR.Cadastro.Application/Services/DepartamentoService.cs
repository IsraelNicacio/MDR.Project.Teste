using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.CadastroDomain.Entities;
using MDR.CadastroDomain.Repositories;

namespace MDR.Cadastro.Application.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DepartamentoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void AdicionarDepartamento(DepartamentoDTO departamento)
    {
        Departamento _departamento = _mapper.Map<Departamento>(departamento);
        _unitOfWork.pessoaRepository.AdicionarDepartamento(_departamento);
        _unitOfWork.Commit();
    }

    public void EditarDepartamento(DepartamentoDTO departamento)
    {
        Departamento _departamento = _mapper.Map<Departamento>(departamento);
        _unitOfWork.pessoaRepository.EditarDepartamento(_departamento);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos()
        => _mapper.Map<IEnumerable<DepartamentoDTO>>(await _unitOfWork.pessoaRepository.RecuperarDepartamentos());

    public async Task<DepartamentoDTO> RecuperarDepartamentoPorId(Guid id)
        => _mapper.Map<DepartamentoDTO>(await _unitOfWork.pessoaRepository.RecuperarDepartamentoPorId(id));
}