using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaDocumentoConfiguration : IEntityTypeConfiguration<CategoriaDocumento>
{
	public void Configure(EntityTypeBuilder<CategoriaDocumento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CategoriaDocumento");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.CategoriaDocumentoId).HasColumnName("Fk_CategoriaDocumento");
		builder.Property(p => p.CssClass).HasMaxLength(50);

		/*builder.HasOne(d => d.CategoriaDocumentoPadre)
			.WithMany(p => p.CategoriasDocumentos)
			.HasForeignKey(d => d.CategoriaDocumentoId);*/

	}
}
