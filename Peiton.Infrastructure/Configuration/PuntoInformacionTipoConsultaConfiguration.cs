using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PuntoInformacionTipoConsultaConfiguration : IEntityTypeConfiguration<PuntoInformacionTipoConsulta>
	{
		public void Configure(EntityTypeBuilder<PuntoInformacionTipoConsulta> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_PuntoInformacionTipoConsulta");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}