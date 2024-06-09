using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CapituloConfiguration : IEntityTypeConfiguration<Capitulo>
	{
		public void Configure(EntityTypeBuilder<Capitulo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Capitulo");
			builder.Property(p => p.Tipo).HasMaxLength(0);
			builder.Property(p => p.Numero).HasMaxLength(10);
			builder.Property(p => p.Descripcion).HasMaxLength(255);

			/*builder.HasOne(d => d.AnoNavigation)
				.WithMany(p => p.Capitulos)
				.HasForeignKey(d => d.Ano);*/

		}
	}
}