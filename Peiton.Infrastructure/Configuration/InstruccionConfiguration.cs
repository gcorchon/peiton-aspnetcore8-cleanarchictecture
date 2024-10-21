using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InstruccionConfiguration : IEntityTypeConfiguration<Instruccion>
{
	public void Configure(EntityTypeBuilder<Instruccion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Instruccion");
		builder.Property(p => p.CategoriaInstruccionId).HasColumnName("Fk_CategoriaInstruccion");
		builder.Property(p => p.Descripcion).HasMaxLength(255);
		builder.Property(p => p.ContentType).HasMaxLength(150);
		builder.Property(p => p.FileName).HasMaxLength(255);
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

		builder.HasOne(d => d.CategoriaInstruccion)
			.WithMany(p => p.Instrucciones)
			.HasForeignKey(d => d.CategoriaInstruccionId);

	}
}
