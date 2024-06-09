using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
	{
		public void Configure(EntityTypeBuilder<Tarea> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Tarea");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.TareaDepartamentoId).HasColumnName("Fk_TareaDepartamento");
			builder.Property(p => p.TareaCategoriaId).HasColumnName("Fk_TareaCategoria");
			builder.Property(p => p.TareaSubcategoriaId).HasColumnName("Fk_TareaSubcategoria");
			builder.Property(p => p.TareaTipoId).HasColumnName("Fk_TareaTipo");
			builder.Property(p => p.UsuarioDistribuidorId).HasColumnName("Fk_UsuarioDistribuidor");
			builder.Property(p => p.UsuarioSolicitanteId).HasColumnName("Fk_UsuarioSolicitante");
			builder.Property(p => p.UsuarioGestorId).HasColumnName("Fk_UsuarioGestor");
			builder.Property(p => p.TareaEstadoId).HasColumnName("Fk_TareaEstado");
			builder.Property(p => p.TareaEntidadId).HasColumnName("Fk_TareaEntidad");
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

			/*builder.HasOne(d => d.TareaCategoria)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TareaCategoriaId);*/

			/*builder.HasOne(d => d.TareaDepartamento)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TareaDepartamentoId);*/

			/*builder.HasOne(d => d.TareaEstado)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TareaEstadoId);*/

			/*builder.HasOne(d => d.TareaSubcategoria)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TareaSubcategoriaId);*/

			/*builder.HasOne(d => d.TareaTipo)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TareaTipoId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.Tareas)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.UsuarioGestor)
				.WithMany(p => p.TareasUsuarioGestor)
				.HasForeignKey(d => d.UsuarioGestorId);*/

			/*builder.HasOne(d => d.UsuarioDistribuidor)
				.WithMany(p => p.TareasUsuarioDistribuidor)
				.HasForeignKey(d => d.UsuarioDistribuidorId);*/

			/*builder.HasOne(d => d.UsuarioSolicitante)
				.WithMany(p => p.TareasUsuarioSolicitante)
				.HasForeignKey(d => d.UsuarioSolicitanteId);*/

		}
	}
}