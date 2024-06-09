using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class MedidaPenalTipoConfiguration : IEntityTypeConfiguration<MedidaPenalTipo>
	{
		public void Configure(EntityTypeBuilder<MedidaPenalTipo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_MedidaPenalTipo");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}