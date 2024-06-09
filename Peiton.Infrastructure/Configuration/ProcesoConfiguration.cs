using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ProcesoConfiguration : IEntityTypeConfiguration<Proceso>
	{
		public void Configure(EntityTypeBuilder<Proceso> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Proceso");
			builder.Property(p => p.CategoriaProcesoId).HasColumnName("Fk_CategoriaProceso");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.ContentType).HasMaxLength(150);
			builder.Property(p => p.FileName).HasMaxLength(255);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

			/*builder.HasOne(d => d.CategoriaProceso)
				.WithMany(p => p.Procesos)
				.HasForeignKey(d => d.CategoriaProcesoId);*/

		}
	}
}