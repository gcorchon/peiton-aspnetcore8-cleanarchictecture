using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
	{
		public void Configure(EntityTypeBuilder<Documento> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Documento");
			builder.Property(p => p.CategoriaDocumentoId).HasColumnName("Fk_CategoriaDocumento");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.ContentType).HasMaxLength(150);
			builder.Property(p => p.FileName).HasMaxLength(255);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Tags).HasMaxLength(512);

			/*builder.HasOne(d => d.CategoriaDocumento)
				.WithMany(p => p.Documentos)
				.HasForeignKey(d => d.CategoriaDocumentoId);*/

		}
	}
}