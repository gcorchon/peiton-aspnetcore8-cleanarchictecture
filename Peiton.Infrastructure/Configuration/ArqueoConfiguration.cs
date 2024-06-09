using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ArqueoConfiguration : IEntityTypeConfiguration<Arqueo>
	{
		public void Configure(EntityTypeBuilder<Arqueo> builder)
		{
			builder.HasKey(t => t.Fecha);

			builder.Property(p => p.Fecha).ValueGeneratedNever();

		}
	}
}