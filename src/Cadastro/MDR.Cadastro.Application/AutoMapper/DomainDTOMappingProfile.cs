﻿using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.CadastroDomain.Entities;

namespace MDR.Cadastro.Application.AutoMapper;

public class DomainDTOMappingProfile : Profile
{
    public DomainDTOMappingProfile()
    {
        CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
    }
}
