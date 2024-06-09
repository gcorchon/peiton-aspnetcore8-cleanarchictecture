using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TuteladoActividadConfiguration : IEntityTypeConfiguration<TuteladoActividad>
	{
		public void Configure(EntityTypeBuilder<TuteladoActividad> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.ActividadId});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.ActividadId).HasColumnName("Fk_Actividad");
			builder.Property(p => p.ActividadLocalizacionId).HasColumnName("Fk_ActividadLocalizacion");

			/*builder.HasOne(d => d.Actividad)
				.WithMany(p => p.TuteladosActividades)
				.HasForeignKey(d => d.ActividadId);*/

			/*builder.HasOne(d => d.ActividadLocalizacion)
				.WithMany(p => p.TuteladosActividades)
				.HasForeignKey(d => d.ActividadLocalizacionId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.TuteladosActividades)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}