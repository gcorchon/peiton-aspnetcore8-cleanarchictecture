using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DiagnosticoConfiguration : IEntityTypeConfiguration<Diagnostico>
	{
		public void Configure(EntityTypeBuilder<Diagnostico> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Diagnostico");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.DiagnosticoId).HasColumnName("Fk_Diagnostico");

		}
	}
}