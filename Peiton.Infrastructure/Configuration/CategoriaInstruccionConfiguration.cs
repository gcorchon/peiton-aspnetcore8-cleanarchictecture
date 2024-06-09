using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CategoriaInstruccionConfiguration : IEntityTypeConfiguration<CategoriaInstruccion>
	{
		public void Configure(EntityTypeBuilder<CategoriaInstruccion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_CategoriaInstruccion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.CategoriaInstruccionId).HasColumnName("Fk_CategoriaInstruccion");
			builder.Property(p => p.CssClass).HasMaxLength(50);

			/*builder.HasOne(d => d.CategoriaInstruccionPadre)
				.WithMany(p => p.CategoriasInstrucciones)
				.HasForeignKey(d => d.CategoriaInstruccionId);*/

		}
	}
}