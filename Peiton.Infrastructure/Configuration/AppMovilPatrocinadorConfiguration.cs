using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilPatrocinadorConfiguration : IEntityTypeConfiguration<AppMovilPatrocinador>
{
	public void Configure(EntityTypeBuilder<AppMovilPatrocinador> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilPatrocinador");
		builder.Property(p => p.Nombre).HasMaxLength(250);
		builder.Property(p => p.Imagen).HasMaxLength(250);
		builder.Property(p => p.Orden).IsRequired();

	}
}
