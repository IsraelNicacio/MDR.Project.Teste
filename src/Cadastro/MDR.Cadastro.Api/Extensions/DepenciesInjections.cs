using AutoMapper.Configuration.Conventions;
using MDR.Cadastro.Application.AutoMapper;
using MDR.Cadastro.Application.Services;
using MDR.CadastroDomain.Repositories;
using MDR.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace MDR.Cadastro.Api.Extensions;

public static class DepenciesInjections
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainDTOMappingProfile));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IDepartamentoService, DepartamentoService>();
    }
}
