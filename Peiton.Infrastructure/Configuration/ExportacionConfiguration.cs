using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ExportacionConfiguration : IEntityTypeConfiguration<Exportacion>
	{
		public void Configure(EntityTypeBuilder<Exportacion> builder)
		{
			builder.HasKey(t => t.DNI);

			builder.Property(p => p.DNI).ValueGeneratedNever().HasMaxLength(50);

		}
	}
}