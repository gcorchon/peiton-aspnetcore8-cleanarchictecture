using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AppMovilTipoTareaConfiguration : IEntityTypeConfiguration<AppMovilTipoTarea>
	{
		public void Configure(EntityTypeBuilder<AppMovilTipoTarea> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AppMovilTipoTarea");
			builder.Property(p => p.Descripcion).HasMaxLength(100);
			builder.Property(p => p.ObjetivoSocialId).HasColumnName("Fk_ObjetivoSocial");

			/*builder.HasOne(d => d.ObjetivoSocial)
				.WithMany(p => p.AppMovilTiposTareas)
				.HasForeignKey(d => d.ObjetivoSocialId);*/

		}
	}
}