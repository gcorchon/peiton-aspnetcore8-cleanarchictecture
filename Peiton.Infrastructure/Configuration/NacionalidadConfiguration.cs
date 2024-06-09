using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class NacionalidadConfiguration : IEntityTypeConfiguration<Nacionalidad>
	{
		public void Configure(EntityTypeBuilder<Nacionalidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Nacionalidad");
			builder.Property(p => p.Nombre).HasMaxLength(50);

		}
	}
}