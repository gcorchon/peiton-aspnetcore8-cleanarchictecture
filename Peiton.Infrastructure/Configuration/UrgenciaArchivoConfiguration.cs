using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UrgenciaArchivoConfiguration : IEntityTypeConfiguration<UrgenciaArchivo>
	{
		public void Configure(EntityTypeBuilder<UrgenciaArchivo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_UrgenciaArchivo");
			builder.Property(p => p.UrgenciaId).HasColumnName("Fk_Urgencia");
			builder.Property(p => p.CategoriaArchivoId).HasColumnName("Fk_CategoriaArchivo");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.ContentType).HasMaxLength(150);
			builder.Property(p => p.FileName).HasMaxLength(255);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Tags).HasMaxLength(512);

			/*builder.HasOne(d => d.CategoriaArchivo)
				.WithMany(p => p.UrgenciasArchivos)
				.HasForeignKey(d => d.CategoriaArchivoId);*/

			/*builder.HasOne(d => d.Urgencia)
				.WithMany(p => p.UrgenciasArchivos)
				.HasForeignKey(d => d.UrgenciaId);*/

		}
	}
}