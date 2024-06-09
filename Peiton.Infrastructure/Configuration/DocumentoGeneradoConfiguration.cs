using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DocumentoGeneradoConfiguration : IEntityTypeConfiguration<DocumentoGenerado>
	{
		public void Configure(EntityTypeBuilder<DocumentoGenerado> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_DocumentoGenerado");
			builder.Property(p => p.CategoriaDocumentoGeneradoId).HasColumnName("Fk_CategoriaDocumentoGenerado");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.ContentType).HasMaxLength(150);
			builder.Property(p => p.FileName).HasMaxLength(255);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Tags).HasMaxLength(512);

			/*builder.HasOne(d => d.CategoriaDocumentoGenerado)
				.WithMany(p => p.DocumentosGenerados)
				.HasForeignKey(d => d.CategoriaDocumentoGeneradoId);*/

		}
	}
}