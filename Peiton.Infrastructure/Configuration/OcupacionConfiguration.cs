using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class OcupacionConfiguration : IEntityTypeConfiguration<Ocupacion>
	{
		public void Configure(EntityTypeBuilder<Ocupacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Ocupacion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}