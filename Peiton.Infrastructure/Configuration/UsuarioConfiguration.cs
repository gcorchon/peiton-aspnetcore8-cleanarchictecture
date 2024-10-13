using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
	public void Configure(EntityTypeBuilder<Usuario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Usuario");
		builder.Property(p => p.Username).HasMaxLength(50);
		builder.Property(p => p.Pwd).HasMaxLength(50);
		builder.Property(p => p.Firma).HasMaxLength(50);
		builder.Property(p => p.Reintentos).IsRequired();
		builder.Property(p => p.Nombre).HasMaxLength(50);
		builder.Property(p => p.Apellidos).HasMaxLength(50);
		builder.Property(p => p.Email).HasMaxLength(255);
		builder.Property(p => p.Bloqueado).IsRequired();
		builder.Property(p => p.Borrado).IsRequired();
		builder.Property(p => p.MostrarEnHome).IsRequired();
		builder.Property(p => p.NombreCompleto).HasComputedColumnSql("(([nombre]+' ')+[apellidos])", false);
		builder.Property(p => p.Imagen).HasMaxLength(255).IsRequired().HasDefaultValueSql("(N'Content/img/icons/persona.png')");
		builder.Property(p => p.Cargo).HasMaxLength(100).IsRequired().HasDefaultValueSql("(N'Desconocido')");
		builder.Property(p => p.TelefonoFijo).HasMaxLength(20);
		builder.Property(p => p.TelefonoMovil).HasMaxLength(20);

		/*builder.HasMany(d => d.ConsultasAlmacenadas)
			.WithMany(p => p.Usuarios)
			.UsingEntity<Dictionary<string, object>>(
		"ConsultaAlmacenadaUsuario",
		l => l.HasOne<ConsultaAlmacenada>().WithMany().HasForeignKey("Fk_ConsultaAlmacenada"),
		r => r.HasOne<Usuario>().WithMany().HasForeignKey("Fk_Usuario"),
		j =>
		{
			j.HasKey("Fk_Usuario", "Fk_ConsultaAlmacenada");
			j.ToTable("ConsultaAlmacenadaUsuario");
			});*/

		/*builder.HasMany(d => d.Eventos)
			.WithMany(p => p.Usuarios)
			.UsingEntity<Dictionary<string, object>>(
		"EventoUsuario",
		l => l.HasOne<Evento>().WithMany().HasForeignKey("Fk_Evento"),
		r => r.HasOne<Usuario>().WithMany().HasForeignKey("Fk_Usuario"),
		j =>
		{
			j.HasKey("Fk_Usuario", "Fk_Evento");
			j.ToTable("EventoUsuario");
			});*/

		/*builder.HasMany(d => d.Grupos)
			.WithMany(p => p.Usuarios)
			.UsingEntity<Dictionary<string, object>>(
		"GrupoUsuario",
		l => l.HasOne<Grupo>().WithMany().HasForeignKey("Fk_Grupo"),
		r => r.HasOne<Usuario>().WithMany().HasForeignKey("Fk_Usuario"),
		j =>
		{
			j.HasKey("Fk_Usuario", "Fk_Grupo");
			j.ToTable("GrupoUsuario");
			});*/

		/*builder.HasMany(d => d.Felicitaciones)
			.WithMany(p => p.Usuarios)
			.UsingEntity<Dictionary<string, object>>(
		"UsuarioFelicitacion",
		l => l.HasOne<Felicitacion>().WithMany().HasForeignKey("Fk_Felicitacion"),
		r => r.HasOne<Usuario>().WithMany().HasForeignKey("Fk_Usuario"),
		j =>
		{
			j.HasKey("Fk_Usuario", "Fk_Felicitacion");
			j.ToTable("UsuarioFelicitacion");
			});*/

		/*builder.HasMany(d => d.Permisos)
			.WithMany(p => p.Usuarios)
			.UsingEntity<Dictionary<string, object>>(
		"UsuarioPermiso",
		l => l.HasOne<Permiso>().WithMany().HasForeignKey("Fk_Permiso"),
		r => r.HasOne<Usuario>().WithMany().HasForeignKey("Fk_Usuario"),
		j =>
		{
			j.HasKey("Fk_Usuario", "Fk_Permiso");
			j.ToTable("UsuarioPermiso");
			});*/
	}
}
