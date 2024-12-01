using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaArchivoConfiguration : IEntityTypeConfiguration<CategoriaArchivo>
{
	public void Configure(EntityTypeBuilder<CategoriaArchivo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CategoriaArchivo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.CategoriaArchivoId).HasColumnName("Fk_CategoriaArchivo");
		builder.Property(p => p.CssClass).HasMaxLength(50);

		builder.HasOne(d => d.CategoriaArchivoPadre)
			.WithMany(p => p.CategoriasArchivos)
			.HasForeignKey(d => d.CategoriaArchivoId);

	}
}
