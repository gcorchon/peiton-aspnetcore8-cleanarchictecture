using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TareaCategoriaConfiguration : IEntityTypeConfiguration<TareaCategoria>
	{
		public void Configure(EntityTypeBuilder<TareaCategoria> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TareaCategoria");
			builder.Property(p => p.TareaDepartamentoId).HasColumnName("Fk_TareaDepartamento");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

			/*builder.HasOne(d => d.TareaDepartamento)
				.WithMany(p => p.TareasCategorias)
				.HasForeignKey(d => d.TareaDepartamentoId);*/

		}
	}
}