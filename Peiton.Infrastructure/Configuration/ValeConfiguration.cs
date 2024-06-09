using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ValeConfiguration : IEntityTypeConfiguration<Vale>
	{
		public void Configure(EntityTypeBuilder<Vale> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Vale");
			builder.Property(p => p.SolicitanteId).HasColumnName("Fk_Solicitante");
			builder.Property(p => p.RevisorId).HasColumnName("Fk_Revisor");
			builder.Property(p => p.AutorizadorId).HasColumnName("Fk_Autorizador");
			builder.Property(p => p.Revisado).IsRequired();
			builder.Property(p => p.Autorizado).IsRequired();
			builder.Property(p => p.Pagado).IsRequired();
			builder.Property(p => p.Rechazado).IsRequired();
			builder.Property(p => p.Importe).HasColumnType("money").IsRequired();
			
			/*builder.HasOne(d => d.Solicitante)
				.WithMany(p => p.ValesSolicitante)
				.HasForeignKey(d => d.SolicitanteId);*/

			/*builder.HasOne(d => d.Revisor)
				.WithMany(p => p.ValesRevisor)
				.HasForeignKey(d => d.RevisorId);*/

			/*builder.HasOne(d => d.Autorizador)
				.WithMany(p => p.ValesAutorizador)
				.HasForeignKey(d => d.AutorizadorId);*/

		}
	}
}