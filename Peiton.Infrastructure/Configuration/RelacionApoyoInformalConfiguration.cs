using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RelacionApoyoInformalConfiguration : IEntityTypeConfiguration<RelacionApoyoInformal>
	{
		public void Configure(EntityTypeBuilder<RelacionApoyoInformal> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_RelacionApoyoInformal");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}