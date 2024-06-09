using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TributoConfiguration : IEntityTypeConfiguration<Tributo>
	{
		public void Configure(EntityTypeBuilder<Tributo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Tributo");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}