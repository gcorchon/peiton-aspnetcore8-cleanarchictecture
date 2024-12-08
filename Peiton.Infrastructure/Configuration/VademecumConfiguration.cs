using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class VademecumConfiguration : IEntityTypeConfiguration<Vademecum>
{
	public void Configure(EntityTypeBuilder<Vademecum> builder)
	{
		builder.HasKey(t => t.Id);
		builder.Property(p => p.Id).HasColumnName("Pk_Vademecum");
	}
}
