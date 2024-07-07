using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
	public class VwCategoriaConfiguration : IEntityTypeConfiguration<VwCategoria>
	{
		public void Configure(EntityTypeBuilder<VwCategoria> builder)
		{
			builder.HasKey(t => t.Id);

			builder.ToView("vwCategoria");
			builder.Property(v => v.Id).HasColumnName("Pk_Categoria");
			builder.Property(v => v.VwCategoriaPadreId).HasColumnName("Fk_CategoriaPadre");
			builder.Property(v => v.TipoCategoriaId).HasColumnName("Fk_TipoCategoria");

			builder.HasOne(d => d.VwCategoriaPadre)
				.WithMany(p => p.VwCategorias)
				.HasForeignKey(d => d.VwCategoriaPadreId);

		}
	}
}