using MDR.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MDR.Cadastro.Api.Extensions;

public static class TenantConfiguration
{
    public static void RegisterTenant(this  IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<CadastroContext>(provider =>
        {
            var optionBuilder = new DbContextOptionsBuilder<CadastroContext>();
            var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
            var tenant = httpContext?.Request.Path.Value?.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];
            var connectionString = configuration.GetConnectionString("TenantDataBase")?.Replace("_DATABASE_", tenant);

            optionBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();

            return new CadastroContext(optionBuilder.Options);
        });
    }
}