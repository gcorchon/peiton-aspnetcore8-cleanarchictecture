using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ConcienciaEnfermedadConfiguration : IEntityTypeConfiguration<ConcienciaEnfermedad>
	{
		public void Configure(EntityTypeBuilder<ConcienciaEnfermedad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ConcienciaEnfermedad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}