using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DiscapacidadPVSConfiguration : IEntityTypeConfiguration<DiscapacidadPVS>
{
	public void Configure(EntityTypeBuilder<DiscapacidadPVS> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_DiscapacidadPVS");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
