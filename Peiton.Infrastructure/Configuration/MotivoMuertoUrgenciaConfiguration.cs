using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MotivoMuertoUrgenciaConfiguration : IEntityTypeConfiguration<MotivoMuertoUrgencia>
{
	public void Configure(EntityTypeBuilder<MotivoMuertoUrgencia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_MotivoMuertoUrgencia");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
