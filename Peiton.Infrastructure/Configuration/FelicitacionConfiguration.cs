using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class FelicitacionConfiguration : IEntityTypeConfiguration<Felicitacion>
	{
		public void Configure(EntityTypeBuilder<Felicitacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Felicitacion");
			builder.Property(p => p.Imagen).HasMaxLength(255);

		}
	}
}