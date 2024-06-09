using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ConsultaAlmacenadaConfiguration : IEntityTypeConfiguration<ConsultaAlmacenada>
	{
		public void Configure(EntityTypeBuilder<ConsultaAlmacenada> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ConsultaAlmacenada");
			builder.Property(p => p.Descripcion).HasMaxLength(500);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.CategoriaConsultaId).HasColumnName("Fk_CategoriaConsulta").IsRequired();

			/*builder.HasOne(d => d.CategoriaConsulta)
				.WithMany(p => p.ConsultasAlmacenadas)
				.HasForeignKey(d => d.CategoriaConsultaId);*/

		}
	}
}