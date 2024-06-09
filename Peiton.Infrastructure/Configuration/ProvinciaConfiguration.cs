using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
	{
		public void Configure(EntityTypeBuilder<Provincia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Provincia");
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.ComunidadAutonomaId).HasColumnName("Fk_ComunidadAutonoma");

			/*builder.HasOne(d => d.ComunidadAutonoma)
				.WithMany(p => p.Provincias)
				.HasForeignKey(d => d.ComunidadAutonomaId);*/

		}
	}
}