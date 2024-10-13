using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleTasadorConfiguration : IEntityTypeConfiguration<InmuebleTasador>
{
	public void Configure(EntityTypeBuilder<InmuebleTasador> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_InmuebleTasador");
		builder.Property(p => p.Nombre).HasMaxLength(50);

	}
}
