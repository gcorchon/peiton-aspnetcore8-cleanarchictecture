using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CajaAMTAConfiguration : IEntityTypeConfiguration<CajaAMTA>
	{
		public void Configure(EntityTypeBuilder<CajaAMTA> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_CajaAMTA");
			builder.Property(p => p.Persona).HasMaxLength(100);
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.CajaId).HasColumnName("Fk_Caja");
			builder.Property(p => p.Importe).HasColumnType("money");
			
			builder.HasOne(d => d.Caja)
				.WithMany(p => p.CajaAMTA)
				.HasForeignKey(d => d.CajaId);

            builder.HasOne(d => d.Tutelado)
                .WithMany(p => p.CajaAMTA)
                .HasForeignKey(d => d.TuteladoId);
        }
	}
}