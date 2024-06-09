using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DondeConvivencionalConfiguration : IEntityTypeConfiguration<DondeConvivencional>
	{
		public void Configure(EntityTypeBuilder<DondeConvivencional> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_DondeConvivencional");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}