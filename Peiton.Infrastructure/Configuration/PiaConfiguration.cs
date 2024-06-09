using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PiaConfiguration : IEntityTypeConfiguration<Pia>
	{
		public void Configure(EntityTypeBuilder<Pia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Pia");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}