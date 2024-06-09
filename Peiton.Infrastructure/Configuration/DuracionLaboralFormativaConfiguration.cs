using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DuracionLaboralFormativaConfiguration : IEntityTypeConfiguration<DuracionLaboralFormativa>
	{
		public void Configure(EntityTypeBuilder<DuracionLaboralFormativa> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_DuracionLaboralFormativa");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}