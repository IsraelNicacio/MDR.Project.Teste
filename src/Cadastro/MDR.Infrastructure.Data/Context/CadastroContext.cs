﻿using MDR.CadastroDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDR.Infrastructure.Data.Context;

public class CadastroContext :DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }

    public CadastroContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);
}
