using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AppMovilTuteladoRecompensaConfiguration : IEntityTypeConfiguration<AppMovilTuteladoRecompensa>
	{
		public void Configure(EntityTypeBuilder<AppMovilTuteladoRecompensa> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AppMovilTuteladoRecompensa");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.AppMovilRecompensaId).HasColumnName("Fk_AppMovilRecompensa");
			builder.Property(p => p.Aprobada).IsRequired();
			builder.Property(p => p.Disfrutada).IsRequired();
			builder.Property(p => p.Notificada).IsRequired();
			builder.Property(p => p.AppMovilVoluntarioId).HasColumnName("Fk_AppMovilVoluntario");

			/*builder.HasOne(d => d.AppMovilRecompensa)
				.WithMany(p => p.AppMovilTuteladosRecompensas)
				.HasForeignKey(d => d.AppMovilRecompensaId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.AppMovilTuteladosRecompensas)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.AppMovilVoluntario)
				.WithMany(p => p.AppMovilTuteladosRecompensas)
				.HasForeignKey(d => d.AppMovilVoluntarioId);*/

		}
	}
}