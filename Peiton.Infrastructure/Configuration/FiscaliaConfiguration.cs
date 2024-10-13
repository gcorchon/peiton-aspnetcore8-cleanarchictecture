using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FiscaliaConfiguration : IEntityTypeConfiguration<Fiscalia>
{
	public void Configure(EntityTypeBuilder<Fiscalia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Fiscalia");
		builder.Property(p => p.Descripcion).HasMaxLength(255);

	}
}
