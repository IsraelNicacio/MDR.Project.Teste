using MDR.CadastroDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDR.Infrastructure.Data.Mappings;

internal class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(120)");

        builder.HasMany(o => o.Pessoas)
            .WithOne(o => o.Departamento);

        builder.ToTable("Departamento");
    }
}
