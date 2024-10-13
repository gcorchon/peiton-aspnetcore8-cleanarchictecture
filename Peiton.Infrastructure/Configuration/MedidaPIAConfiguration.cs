using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MedidaPIAConfiguration : IEntityTypeConfiguration<MedidaPIA>
{
	public void Configure(EntityTypeBuilder<MedidaPIA> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_MedidaPIA");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
