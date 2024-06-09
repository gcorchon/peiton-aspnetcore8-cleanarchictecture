using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoCuratelaConfiguration : IEntityTypeConfiguration<TipoCuratela>
	{
		public void Configure(EntityTypeBuilder<TipoCuratela> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoCuratela");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

			/*builder.HasMany(d => d.DatosJuridicosHistoricos)
				.WithMany(p => p.TiposCuratelas)
				.UsingEntity<Dictionary<string, object>>(
			"DatosJuridicosHistoricoTipoCuratelaAsistencial",
			l => l.HasOne<DatosJuridicosHistorico>().WithMany().HasForeignKey("Fk_DatosJuridicosHistorico"),
			r => r.HasOne<TipoCuratela>().WithMany().HasForeignKey("Fk_TipoCuratela"),
			j =>
			{
				j.HasKey("Fk_TipoCuratela", "Fk_DatosJuridicosHistorico");
				j.ToTable("DatosJuridicosHistoricoTipoCuratelaAsistencial");
				});*/

				/*builder.HasMany(d => d.DatosJuridicosHistoricos)
					.WithMany(p => p.TiposCuratelas)
					.UsingEntity<Dictionary<string, object>>(
				"DatosJuridicosHistoricoTipoCuratelaRepresentativa",
				l => l.HasOne<DatosJuridicosHistorico>().WithMany().HasForeignKey("Fk_DatosJuridicosHistorico"),
				r => r.HasOne<TipoCuratela>().WithMany().HasForeignKey("Fk_TipoCuratela"),
				j =>
				{
					j.HasKey("Fk_TipoCuratela", "Fk_DatosJuridicosHistorico");
					j.ToTable("DatosJuridicosHistoricoTipoCuratelaRepresentativa");
					});*/
				}
			}
		}