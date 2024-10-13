using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DirectorioAMTAConfiguration : IEntityTypeConfiguration<DirectorioAMTA>
{
	public void Configure(EntityTypeBuilder<DirectorioAMTA> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_DirectorioAMTA");
		builder.Property(p => p.NombreCompleto).HasMaxLength(100);
		builder.Property(p => p.Cargo).HasMaxLength(100);
		builder.Property(p => p.Grupos).HasMaxLength(100);
		builder.Property(p => p.TelefonoFijo).HasMaxLength(20);
		builder.Property(p => p.Extension).HasMaxLength(20);
		builder.Property(p => p.TelefonoMovil).HasMaxLength(20);
		builder.Property(p => p.Email).HasMaxLength(100);
		builder.Property(p => p.Imagen).HasMaxLength(255);
		builder.Property(p => p.CPU).HasMaxLength(50);
		builder.Property(p => p.Monitor).HasMaxLength(50);
		builder.Property(p => p.Edificio).HasMaxLength(50);
		builder.Property(p => p.Planta).HasMaxLength(50);
		builder.Property(p => p.Firma).HasMaxLength(50);
		builder.Property(p => p.NumeroPuesto).HasMaxLength(20);
		builder.Property(p => p.Dni).HasMaxLength(10);
		builder.Property(p => p.Webcam).HasMaxLength(6);
		builder.Property(p => p.Tablet).HasMaxLength(50);
		builder.Property(p => p.SegundaPantalla).HasMaxLength(50);
		builder.Property(p => p.Imei).HasMaxLength(50);
		builder.Property(p => p.Mostrar).IsRequired();
		builder.Property(p => p.Portatil).HasMaxLength(50);

	}
}
