using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ProcedimientoConfiguration : IEntityTypeConfiguration<Procedimiento>
	{
		public void Configure(EntityTypeBuilder<Procedimiento> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Procedimiento");
			builder.Property(p => p.Descripcion).HasMaxLength(100);
			builder.Property(p => p.Normal).IsRequired();
			builder.Property(p => p.Adicional).IsRequired();
			builder.Property(p => p.OrdenJurisdiccionalId).HasColumnName("Fk_OrdenJurisdiccional");

			/*builder.HasOne(d => d.OrdenJurisdiccional)
				.WithMany(p => p.Procedimientos)
				.HasForeignKey(d => d.OrdenJurisdiccionalId);*/

		}
	}
}