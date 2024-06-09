using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class QuejaMotivoConfiguration : IEntityTypeConfiguration<QuejaMotivo>
	{
		public void Configure(EntityTypeBuilder<QuejaMotivo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_QuejaMotivo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

			/*builder.HasMany(d => d.Quejas)
				.WithMany(p => p.QuejasMotivos)
				.UsingEntity<Dictionary<string, object>>(
			"QuejaQuejaMotivo",
			l => l.HasOne<Queja>().WithMany().HasForeignKey("Fk_Queja"),
			r => r.HasOne<QuejaMotivo>().WithMany().HasForeignKey("Fk_QuejaMotivo"),
			j =>
			{
				j.HasKey("Fk_QuejaMotivo", "Fk_Queja");
				j.ToTable("QuejaQuejaMotivo");
				});*/
			}
		}
	}