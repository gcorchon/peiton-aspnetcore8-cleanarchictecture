using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ArrendamientoInquilinoConfiguration : IEntityTypeConfiguration<ArrendamientoInquilino>
	{
		public void Configure(EntityTypeBuilder<ArrendamientoInquilino> builder)
		{
			builder.HasKey(t => new { t.ArrendamientoId, t.Orden});

			builder.Property(p => p.ArrendamientoId).HasColumnName("Fk_Arrendamiento");
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.Contacto).HasMaxLength(50);
			builder.Property(p => p.DNI).HasMaxLength(20);

			/*builder.HasOne(d => d.Arrendamiento)
				.WithMany(p => p.ArrendamientosInquilinos)
				.HasForeignKey(d => d.ArrendamientoId);*/

		}
	}
}