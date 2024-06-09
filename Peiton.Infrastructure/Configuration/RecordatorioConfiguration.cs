using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RecordatorioConfiguration : IEntityTypeConfiguration<Recordatorio>
	{
		public void Configure(EntityTypeBuilder<Recordatorio> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Recordatorio");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}