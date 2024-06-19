using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleAvisoCosteConfiguration : IEntityTypeConfiguration<InmuebleAvisoCoste>
	{
		public void Configure(EntityTypeBuilder<InmuebleAvisoCoste> builder)
		{
			builder.HasKey(t => new { t.InmuebleAvisoId, t.Orden});

			builder.Property(p => p.InmuebleAvisoId).HasColumnName("Fk_InmuebleAviso");
			builder.Property(p => p.EmpresaId).HasColumnName("Fk_Empresa");
			builder.Property(p => p.CosteId).HasMaxLength(36).HasDefaultValueSql("(newid())");
			builder.Property(p => p.Importe).HasColumnType("money");
			/*builder.HasOne(d => d.Empresa)
				.WithMany(p => p.InmueblesAvisosCostes)
				.HasForeignKey(d => d.EmpresaId);*/

			builder.HasOne(d => d.InmuebleAviso)
				.WithMany(p => p.InmuebleAvisosCostes)
				.HasForeignKey(d => d.InmuebleAvisoId);

		}
	}
}