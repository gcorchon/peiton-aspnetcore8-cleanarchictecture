using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DistritoConfiguration : IEntityTypeConfiguration<Distrito>
	{
		public void Configure(EntityTypeBuilder<Distrito> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Distrito");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}