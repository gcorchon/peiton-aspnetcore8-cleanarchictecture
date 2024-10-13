using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaDocumentoGeneradoConfiguration : IEntityTypeConfiguration<CategoriaDocumentoGenerado>
{
	public void Configure(EntityTypeBuilder<CategoriaDocumentoGenerado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CategoriaDocumentoGenerado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.CategoriaDocumentoGeneradoId).HasColumnName("Fk_CategoriaDocumentoGenerado");
		builder.Property(p => p.CssClass).HasMaxLength(50);

		/*builder.HasOne(d => d.CategoriaDocumentoGeneradoPadre)
			.WithMany(p => p.CategoriasDocumentosGenerados)
			.HasForeignKey(d => d.CategoriaDocumentoGeneradoId);*/

	}
}
