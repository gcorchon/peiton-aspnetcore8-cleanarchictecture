using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DatosEconomicosConfiguration : IEntityTypeConfiguration<DatosEconomicos>
	{
		public void Configure(EntityTypeBuilder<DatosEconomicos> builder)
		{
			builder.HasKey(t => t.TuteladoId);

			builder.Property(p => p.TuteladoId).ValueGeneratedNever().HasColumnName("Fk_Tutelado");
			builder.Property(p => p.ExentoIRPF).IsRequired();

			builder.HasOne(d => d.Tutelado)
				.WithOne(p => p.DatosEconomicos)
				.HasForeignKey<DatosEconomicos>(t => t.TuteladoId);

		}
	}
}