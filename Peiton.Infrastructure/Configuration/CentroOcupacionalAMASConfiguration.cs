using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CentroOcupacionalAMASConfiguration : IEntityTypeConfiguration<CentroOcupacionalAMAS>
	{
		public void Configure(EntityTypeBuilder<CentroOcupacionalAMAS> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_CentroOcupacionalAMAS");
			builder.Property(p => p.Nombre).HasMaxLength(255);

		}
	}
}