using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class QuejaTipoConfiguration : IEntityTypeConfiguration<QuejaTipo>
	{
		public void Configure(EntityTypeBuilder<QuejaTipo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_QuejaTipo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Nomenclatura).HasMaxLength(10);

		}
	}
}