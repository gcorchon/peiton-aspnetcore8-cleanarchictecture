using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UtilizacionConfiguration : IEntityTypeConfiguration<Utilizacion>
	{
		public void Configure(EntityTypeBuilder<Utilizacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Utilizacion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}