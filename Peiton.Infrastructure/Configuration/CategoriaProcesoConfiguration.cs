using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CategoriaProcesoConfiguration : IEntityTypeConfiguration<CategoriaProceso>
	{
		public void Configure(EntityTypeBuilder<CategoriaProceso> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_CategoriaProceso");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.CategoriaProcesoId).HasColumnName("Fk_CategoriaProceso");
			builder.Property(p => p.CssClass).HasMaxLength(50);

			/*builder.HasOne(d => d.CategoriaProcesoPadre)
				.WithMany(p => p.CategoriasProcesos)
				.HasForeignKey(d => d.CategoriaProcesoId);*/

		}
	}
}