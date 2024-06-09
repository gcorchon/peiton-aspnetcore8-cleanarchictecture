using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AppMovilTuteladoConfiguration : IEntityTypeConfiguration<AppMovilTutelado>
	{
		public void Configure(EntityTypeBuilder<AppMovilTutelado> builder)
		{
			builder.HasKey(t => t.TuteladoId);

			builder.Property(p => p.TuteladoId).ValueGeneratedNever().HasColumnName("Fk_Tutelado");
			builder.Property(p => p.NumeroTelefono).HasMaxLength(4);
			builder.Property(p => p.CodigoValidacion).HasMaxLength(3);
			builder.Property(p => p.OneSignalId).HasMaxLength(64);
			builder.Property(p => p.SolicitarRecompensas).IsRequired();
			builder.Property(p => p.InformacionComercial).IsRequired();

			builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.AppMovilTutelados)
				.HasForeignKey(d => d.TuteladoId);

		}
	}
}