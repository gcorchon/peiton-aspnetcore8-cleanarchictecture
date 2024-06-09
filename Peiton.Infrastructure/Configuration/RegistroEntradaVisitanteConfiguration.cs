using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RegistroEntradaVisitanteConfiguration : IEntityTypeConfiguration<RegistroEntradaVisitante>
	{
		public void Configure(EntityTypeBuilder<RegistroEntradaVisitante> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_RegistroEntradaVisitante");
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.Dni).HasMaxLength(20);

		}
	}
}