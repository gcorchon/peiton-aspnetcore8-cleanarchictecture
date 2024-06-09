using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleTipoAutorizacionConfiguration : IEntityTypeConfiguration<InmuebleTipoAutorizacion>
	{
		public void Configure(EntityTypeBuilder<InmuebleTipoAutorizacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_InmuebleTipoAutorizacion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}