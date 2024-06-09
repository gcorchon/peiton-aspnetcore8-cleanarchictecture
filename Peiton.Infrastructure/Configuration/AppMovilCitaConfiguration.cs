using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AppMovilCitaConfiguration : IEntityTypeConfiguration<AppMovilCita>
	{
		public void Configure(EntityTypeBuilder<AppMovilCita> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AppMovilCita");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.AppMovilPeriodicidadId).HasColumnName("Fk_AppMovilPeriodicidad");
			builder.Property(p => p.Titulo).HasMaxLength(255);

			/*builder.HasOne(d => d.AppMovilPeriodicidad)
				.WithMany(p => p.AppMovilCitas)
				.HasForeignKey(d => d.AppMovilPeriodicidadId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.AppMovilCitas)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}