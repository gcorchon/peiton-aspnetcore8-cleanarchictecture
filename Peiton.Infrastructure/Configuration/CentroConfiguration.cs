using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CentroConfiguration : IEntityTypeConfiguration<Centro>
{
	public void Configure(EntityTypeBuilder<Centro> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Centro");
		builder.Property(p => p.Nombre).HasMaxLength(255);
		builder.Property(p => p.Via).HasMaxLength(255);
		builder.Property(p => p.Direccion).HasMaxLength(255);
		builder.Property(p => p.Numero).HasMaxLength(50);
		builder.Property(p => p.CP).HasMaxLength(5);
		builder.Property(p => p.Poblacion).HasMaxLength(255);
		builder.Property(p => p.Distrito).HasMaxLength(50);
		builder.Property(p => p.Ciudad).HasMaxLength(255);
		builder.Property(p => p.Telefono1).HasMaxLength(50);
		builder.Property(p => p.Telefono2).HasMaxLength(50);
		builder.Property(p => p.Fax).HasMaxLength(50);
		builder.Property(p => p.Portal).HasMaxLength(50);
		builder.Property(p => p.Escalera).HasMaxLength(50);
		builder.Property(p => p.Piso).HasMaxLength(50);
		builder.Property(p => p.Letra).HasMaxLength(50);
		builder.Property(p => p.Tipologia).IsRequired();
		builder.Property(p => p.Amas).IsRequired();
		builder.Property(p => p.Residencial).IsRequired();
		builder.Property(p => p.Diurno).IsRequired();

	}
}
