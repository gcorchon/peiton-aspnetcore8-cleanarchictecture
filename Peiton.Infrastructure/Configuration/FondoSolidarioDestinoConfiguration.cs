using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class FondoSolidarioDestinoConfiguration : IEntityTypeConfiguration<FondoSolidarioDestino>
	{
		public void Configure(EntityTypeBuilder<FondoSolidarioDestino> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidarioDestino");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.FondoSolidarioTipoFondoId).HasColumnName("Fk_FondoSolidarioTipoFondo");

			/*builder.HasOne(d => d.FondoSolidarioTipoFondo)
				.WithMany(p => p.FondosSolidariosDestinos)
				.HasForeignKey(d => d.FondoSolidarioTipoFondoId);*/

		}
	}
}