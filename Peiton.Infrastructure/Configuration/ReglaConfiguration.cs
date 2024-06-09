using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ReglaConfiguration : IEntityTypeConfiguration<Regla>
	{
		public void Configure(EntityTypeBuilder<Regla> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Regla");
			builder.Property(p => p.Texto).HasMaxLength(255);
			builder.Property(p => p.CategoriaId).HasColumnName("Fk_Categoria");

			/*builder.HasOne(d => d.Categoria)
				.WithMany(p => p.Reglas)
				.HasForeignKey(d => d.CategoriaId);*/

		}
	}
}