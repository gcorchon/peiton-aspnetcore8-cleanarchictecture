using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class LauConfiguration : IEntityTypeConfiguration<Lau>
	{
		public void Configure(EntityTypeBuilder<Lau> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Lau");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}