using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class OrdenJurisdiccionalConfiguration : IEntityTypeConfiguration<OrdenJurisdiccional>
	{
		public void Configure(EntityTypeBuilder<OrdenJurisdiccional> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_OrdenJurisdiccional");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}