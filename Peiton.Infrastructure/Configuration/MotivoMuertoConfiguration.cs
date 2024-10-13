using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MotivoMuertoConfiguration : IEntityTypeConfiguration<MotivoMuerto>
{
	public void Configure(EntityTypeBuilder<MotivoMuerto> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_MotivoMuerto");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
