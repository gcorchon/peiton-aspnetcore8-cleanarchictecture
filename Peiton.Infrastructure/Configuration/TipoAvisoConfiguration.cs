using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoAvisoConfiguration : IEntityTypeConfiguration<TipoAviso>
	{
		public void Configure(EntityTypeBuilder<TipoAviso> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoAviso");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Importe).HasColumnType("money");
		}
	}
}