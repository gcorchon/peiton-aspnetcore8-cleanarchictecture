using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CategoriaConsultaConfiguration : IEntityTypeConfiguration<CategoriaConsulta>
	{
		public void Configure(EntityTypeBuilder<CategoriaConsulta> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_CategoriaConsulta");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}