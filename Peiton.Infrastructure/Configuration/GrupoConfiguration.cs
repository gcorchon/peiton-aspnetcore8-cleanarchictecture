using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Id).HasColumnName("Pk_Grupo");
        builder.Property(p => p.Descripcion).HasMaxLength(50);

        builder.HasMany(d => d.Usuarios)
        .WithMany(u => u.Grupos)
    .UsingEntity(
        "GrupoUsuario",
            l => l.HasOne(typeof(Usuario)).WithMany().HasForeignKey("Fk_Usuario").HasPrincipalKey(nameof(Usuario.Id)),
            r => r.HasOne(typeof(Grupo)).WithMany().HasForeignKey("Fk_Grupo").HasPrincipalKey(nameof(Grupo.Id)),
            j => j.HasKey("Fk_Grupo", "Fk_Usuario"));

        /*builder.HasMany(d => d.ConsultasAlmacenadas)
            .WithMany(p => p.Grupos)
            .UsingEntity<Dictionary<string, object>>(
        "ConsultaAlmacenadaGrupo",
        l => l.HasOne<ConsultaAlmacenada>().WithMany().HasForeignKey("Fk_ConsultaAlmacenada"),
        r => r.HasOne<Grupo>().WithMany().HasForeignKey("Fk_Grupo"),
        j =>
        {
            j.HasKey("Fk_Grupo", "Fk_ConsultaAlmacenada");
            j.ToTable("ConsultaAlmacenadaGrupo");
            });*/

        /*builder.HasMany(d => d.Eventos)
            .WithMany(p => p.Grupos)
            .UsingEntity<Dictionary<string, object>>(
        "EventoGrupo",
        l => l.HasOne<Evento>().WithMany().HasForeignKey("Fk_Evento"),
        r => r.HasOne<Grupo>().WithMany().HasForeignKey("Fk_Grupo"),
        j =>
        {
            j.HasKey("Fk_Grupo", "Fk_Evento");
            j.ToTable("EventoGrupo");
            });*/
    }
}
