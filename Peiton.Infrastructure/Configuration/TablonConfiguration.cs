using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TablonConfiguration : IEntityTypeConfiguration<Tablon>
	{
		public void Configure(EntityTypeBuilder<Tablon> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Tablon");
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.Tablones)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}