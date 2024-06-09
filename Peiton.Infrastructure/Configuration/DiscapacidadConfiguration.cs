using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DiscapacidadConfiguration : IEntityTypeConfiguration<Discapacidad>
	{
		public void Configure(EntityTypeBuilder<Discapacidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Discapacidad");
			builder.Property(p => p.Descripcion).HasMaxLength(20);

		}
	}
}