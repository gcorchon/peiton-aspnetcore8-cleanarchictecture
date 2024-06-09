using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
	{
		public void Configure(EntityTypeBuilder<Sala> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Sala");
			builder.Property(p => p.Descripcion).HasMaxLength(255);

		}
	}
}