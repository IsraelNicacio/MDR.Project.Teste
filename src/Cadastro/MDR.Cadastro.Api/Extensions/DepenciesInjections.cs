using AutoMapper.Configuration.Conventions;
using MDR.Cadastro.Application.AutoMapper;
using MDR.Cadastro.Application.Services;
using MDR.CadastroDomain.Repositories;
using MDR.Infrastructure.Data.Context;
using MDR.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

public static class TenantConfiguration
{
    public static void RegisterTenant(this  IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<CadastroContext>(provider =>
        {
            var optionBuilder = new DbContextOptionsBuilder<CadastroContext>();
            var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
            var tenant = httpContext.Request.Path.Value?.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];
            var connectionString = configuration.GetConnectionString("TenantDataBase")?.Replace("_DATABASE_", tenant);

            optionBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();

            return new CadastroContext(optionBuilder.Options);
        });
    }
}