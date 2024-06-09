using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EscritoSucursalConfiguration : IEntityTypeConfiguration<EscritoSucursal>
	{
		public void Configure(EntityTypeBuilder<EscritoSucursal> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.EntidadFinancieraId, t.Numero});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
			builder.Property(p => p.Numero).HasMaxLength(2);

			/*builder.HasOne(d => d.EntidadFinanciera)
				.WithMany(p => p.EscritosSucursales)
				.HasForeignKey(d => d.EntidadFinancieraId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.EscritosSucursales)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}