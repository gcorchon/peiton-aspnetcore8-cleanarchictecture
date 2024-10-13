using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ComunicadoConfiguration : IEntityTypeConfiguration<Comunicado>
{
	public void Configure(EntityTypeBuilder<Comunicado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Comunicado");
		builder.Property(p => p.FileName).HasMaxLength(255);

	}
}
