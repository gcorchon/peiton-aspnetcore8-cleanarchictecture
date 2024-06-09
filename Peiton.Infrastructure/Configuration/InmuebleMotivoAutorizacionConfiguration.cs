using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleMotivoAutorizacionConfiguration : IEntityTypeConfiguration<InmuebleMotivoAutorizacion>
	{
		public void Configure(EntityTypeBuilder<InmuebleMotivoAutorizacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_InmuebleMotivoAutorizacion");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.InmuebleTipoAutorizacionId).HasColumnName("Fk_InmuebleTipoAutorizacion");

			/*builder.HasOne(d => d.InmuebleTipoAutorizacion)
				.WithMany(p => p.InmueblesMotivosAutorizaciones)
				.HasForeignKey(d => d.InmuebleTipoAutorizacionId);*/

		}
	}
}