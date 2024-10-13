using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
	public void Configure(EntityTypeBuilder<Categoria> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Categoria");
		builder.Property(p => p.Descripcion).HasMaxLength(255);
		builder.Property(p => p.TipoCategoriaId).HasColumnName("Fk_TipoCategoria");
		builder.Property(p => p.CategoriaPadreId).HasColumnName("Fk_CategoriaPadre");
		builder.Property(p => p.Visible).IsRequired();

		/*builder.HasOne(d => d.CategoriaPadre)
			.WithMany(p => p.Categorias)
			.HasForeignKey(d => d.CategoriaPadreId);*/

		/*builder.HasOne(d => d.TipoCategoria)
			.WithMany(p => p.Categorias)
			.HasForeignKey(d => d.TipoCategoriaId);*/

	}
}
