using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilRecompensaConfiguration : IEntityTypeConfiguration<AppMovilRecompensa>
{
	public void Configure(EntityTypeBuilder<AppMovilRecompensa> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilRecompensa");
		builder.Property(p => p.Titulo).HasMaxLength(128);
		builder.Property(p => p.Imagen).HasMaxLength(255);
		builder.Property(p => p.Visible).IsRequired();
		builder.Property(p => p.Dias).IsRequired();

	}
}
