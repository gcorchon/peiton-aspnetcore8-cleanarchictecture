using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class SeguroConfiguration : IEntityTypeConfiguration<Seguro>
	{
		public void Configure(EntityTypeBuilder<Seguro> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Seguro");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}