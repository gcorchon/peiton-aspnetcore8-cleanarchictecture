using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AnoPresupuestarioConfiguration : IEntityTypeConfiguration<AnoPresupuestario>
	{
		public void Configure(EntityTypeBuilder<AnoPresupuestario> builder)
		{
			builder.HasKey(t => t.Ano);

			builder.Property(p => p.Ano).ValueGeneratedNever();
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.SaldoInicialBanco).HasColumnType("money");
			builder.Property(p => p.SaldoInicialCaja).HasColumnType("money");
		}
	}
}