using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RequerimientoOrigenConfiguration : IEntityTypeConfiguration<RequerimientoOrigen>
{
    public void Configure(EntityTypeBuilder<RequerimientoOrigen> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Id).HasColumnName("Pk_RequerimientoOrigen");
        builder.Property(p => p.Descripcion).HasMaxLength(50);

    }
}
