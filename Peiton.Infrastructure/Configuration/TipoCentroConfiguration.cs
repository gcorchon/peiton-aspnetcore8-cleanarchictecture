using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoCentroConfiguration : IEntityTypeConfiguration<TipoCentro>
	{
		public void Configure(EntityTypeBuilder<TipoCentro> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoCentro");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}