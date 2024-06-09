using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TareaSubcategoriaConfiguration : IEntityTypeConfiguration<TareaSubcategoria>
	{
		public void Configure(EntityTypeBuilder<TareaSubcategoria> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TareaSubcategoria");
			builder.Property(p => p.TareaCategoriaId).HasColumnName("Fk_TareaCategoria");
			builder.Property(p => p.Descripcion).HasMaxLength(255);

			/*builder.HasOne(d => d.TareaCategoria)
				.WithMany(p => p.TareasSubcategorias)
				.HasForeignKey(d => d.TareaCategoriaId);*/

		}
	}
}