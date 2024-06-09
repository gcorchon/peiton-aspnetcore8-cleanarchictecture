using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InformePersonalPIAConfiguration : IEntityTypeConfiguration<InformePersonalPIA>
	{
		public void Configure(EntityTypeBuilder<InformePersonalPIA> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_InformePersonalPIA");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.IP).HasMaxLength(7);
			builder.Property(p => p.MedidaPIAId).HasColumnName("Fk_MedidaPIA");
			builder.Property(p => p.ParticipacionUsuarioPIAId).HasColumnName("Fk_ParticipacionUsuarioPIA");

			/*builder.HasOne(d => d.MedidaPIA)
				.WithMany(p => p.InformesPersonalesPIA)
				.HasForeignKey(d => d.MedidaPIAId);*/

			/*builder.HasOne(d => d.ParticipacionUsuarioPIA)
				.WithMany(p => p.InformesPersonalesPIA)
				.HasForeignKey(d => d.ParticipacionUsuarioPIAId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.InformesPersonalesPIA)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.InformesPersonalesPIA)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}