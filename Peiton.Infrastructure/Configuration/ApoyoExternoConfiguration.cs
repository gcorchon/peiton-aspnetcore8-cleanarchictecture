using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ApoyoExternoConfiguration : IEntityTypeConfiguration<ApoyoExterno>
	{
		public void Configure(EntityTypeBuilder<ApoyoExterno> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_ApoyoExterno");
			builder.Property(p => p.Descripcion).HasMaxLength(250);

		}
	}
}