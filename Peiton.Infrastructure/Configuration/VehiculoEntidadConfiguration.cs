using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class VehiculoEntidadConfiguration : IEntityTypeConfiguration<VehiculoEntidad>
	{
		public void Configure(EntityTypeBuilder<VehiculoEntidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_VehiculoEntidad");
			builder.Property(p => p.Nombre).HasMaxLength(255);
			builder.Property(p => p.Matricula).HasMaxLength(10);
			builder.Property(p => p.Marca).HasMaxLength(50);
			builder.Property(p => p.Modelo).HasMaxLength(50);
			builder.Property(p => p.Color).HasMaxLength(50);
			builder.Property(p => p.Combustible).HasMaxLength(50);

		}
	}
}