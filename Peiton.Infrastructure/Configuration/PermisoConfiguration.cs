using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
	{
		public void Configure(EntityTypeBuilder<Permiso> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Permiso");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.JsName).HasMaxLength(255);
			builder.Property(p => p.PermisoId).HasColumnName("Fk_Permiso");
			builder.Property(p => p.Visible).IsRequired();

			/*builder.HasMany(d => d.Grupos)
				.WithMany(p => p.Permisos)
				.UsingEntity<Dictionary<string, object>>(
			"GrupoPermiso",
			l => l.HasOne<Grupo>().WithMany().HasForeignKey("Fk_Grupo"),
			r => r.HasOne<Permiso>().WithMany().HasForeignKey("Fk_Permiso"),
			j =>
			{
				j.HasKey("Fk_Permiso", "Fk_Grupo");
				j.ToTable("GrupoPermiso");
				});*/
			}
		}
	}