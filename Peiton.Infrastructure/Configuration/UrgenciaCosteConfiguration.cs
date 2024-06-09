using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UrgenciaCosteConfiguration : IEntityTypeConfiguration<UrgenciaCoste>
	{
		public void Configure(EntityTypeBuilder<UrgenciaCoste> builder)
		{
			builder.HasKey(t => new { t.UrgenciaId, t.Orden});

			builder.Property(p => p.UrgenciaId).HasColumnName("Fk_Urgencia");
			builder.Property(p => p.UrgenciaConceptoCosteId).HasColumnName("Fk_UrgenciaConceptoCoste");
			builder.Property(p => p.Valoracion).HasColumnType("money").IsRequired();
			
			/*builder.HasOne(d => d.Urgencia)
				.WithMany(p => p.UrgenciasCostes)
				.HasForeignKey(d => d.UrgenciaId);*/

			/*builder.HasOne(d => d.UrgenciaConceptoCoste)
				.WithMany(p => p.UrgenciasCostes)
				.HasForeignKey(d => d.UrgenciaConceptoCosteId);*/

		}
	}
}