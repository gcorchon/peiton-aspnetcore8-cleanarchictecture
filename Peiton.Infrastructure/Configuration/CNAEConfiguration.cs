using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CNAEConfiguration : IEntityTypeConfiguration<CNAE>
	{
		public void Configure(EntityTypeBuilder<CNAE> builder)
		{
			builder.HasKey(t => t.Cnae2009);

			builder.Property(p => p.Cnae2009).ValueGeneratedNever().HasMaxLength(2);
			builder.Property(p => p.Description).HasMaxLength(255);

			/*builder.HasMany(d => d.Categorias)
				.WithMany(p => p.CNAE)
				.UsingEntity<Dictionary<string, object>>(
			"CNAECategoria",
			l => l.HasOne<Categoria>().WithMany().HasForeignKey("Fk_Categoria"),
			r => r.HasOne<CNAE>().WithMany().HasForeignKey("Cnae2009"),
			j =>
			{
				j.HasKey("Cnae2009", "Fk_Categoria");
				j.ToTable("CNAECategoria");
				});*/
			}
		}
	}