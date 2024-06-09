using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UrgenciaOrigenConfiguration : IEntityTypeConfiguration<UrgenciaOrigen>
	{
		public void Configure(EntityTypeBuilder<UrgenciaOrigen> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_UrgenciaOrigen");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}