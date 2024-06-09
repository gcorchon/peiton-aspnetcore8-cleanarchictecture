using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleTipoAvisoConfiguration : IEntityTypeConfiguration<InmuebleTipoAviso>
	{
		public void Configure(EntityTypeBuilder<InmuebleTipoAviso> builder)
		{
			builder.HasKey(t => new { t.InmuebleAvisoId, t.Orden});

			builder.Property(p => p.InmuebleAvisoId).HasColumnName("Fk_InmuebleAviso");
			builder.Property(p => p.TipoAvisoId).HasColumnName("Fk_TipoAviso");
			builder.Property(p => p.Importe).HasColumnType("money");
			/*builder.HasOne(d => d.InmuebleAviso)
				.WithMany(p => p.InmueblesTiposAvisos)
				.HasForeignKey(d => d.InmuebleAvisoId);*/

			/*builder.HasOne(d => d.TipoAviso)
				.WithMany(p => p.InmueblesTiposAvisos)
				.HasForeignKey(d => d.TipoAvisoId);*/

		}
	}
}