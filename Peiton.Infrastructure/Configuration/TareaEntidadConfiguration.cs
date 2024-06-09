using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TareaEntidadConfiguration : IEntityTypeConfiguration<TareaEntidad>
	{
		public void Configure(EntityTypeBuilder<TareaEntidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TareaEntidad");
			builder.Property(p => p.Descripcion).HasMaxLength(255);

		}
	}
}