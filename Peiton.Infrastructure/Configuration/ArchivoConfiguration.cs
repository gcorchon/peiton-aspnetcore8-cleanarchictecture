using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ArchivoConfiguration : IEntityTypeConfiguration<Archivo>
{
	public void Configure(EntityTypeBuilder<Archivo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Archivo");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.CategoriaArchivoId).HasColumnName("Fk_CategoriaArchivo");
		builder.Property(p => p.Descripcion).HasMaxLength(255);
		builder.Property(p => p.ContentType).HasMaxLength(150);
		builder.Property(p => p.FileName).HasMaxLength(255);
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Tags).HasMaxLength(512);
		builder.Property(p => p.TuAppoyo).IsRequired();

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Archivos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
