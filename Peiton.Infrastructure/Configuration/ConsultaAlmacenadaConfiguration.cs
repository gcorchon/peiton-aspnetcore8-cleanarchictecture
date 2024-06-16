using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;

public class ConsultaAlmacenadaConfiguration : IEntityTypeConfiguration<ConsultaAlmacenada>
{
    public void Configure(EntityTypeBuilder<ConsultaAlmacenada> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Id).HasColumnName("Pk_ConsultaAlmacenada");
        builder.Property(p => p.Descripcion).HasMaxLength(500);
        builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
        builder.Property(p => p.CategoriaConsultaId).HasColumnName("Fk_CategoriaConsulta").IsRequired();

        builder.HasMany(d => d.Usuarios)
            .WithMany(u => u.ConsultasAlmacenadas)
        .UsingEntity(
            "ConsultaAlmacenadaUsuario",
                l => l.HasOne(typeof(Usuario)).WithMany().HasForeignKey("Fk_Usuario").HasPrincipalKey(nameof(Usuario.Id)),
                r => r.HasOne(typeof(ConsultaAlmacenada)).WithMany().HasForeignKey("Fk_ConsultaAlmacenada").HasPrincipalKey(nameof(ConsultaAlmacenada.Id)),
                j => j.HasKey("Fk_ConsultaAlmacenada", "Fk_Usuario"));

        builder.HasMany(d => d.Grupos)
            .WithMany(u => u.ConsultasAlmacenadas)
            .UsingEntity(
                "ConsultaAlmacenadaGrupo",
                    l => l.HasOne(typeof(Grupo)).WithMany().HasForeignKey("Fk_Grupo").HasPrincipalKey(nameof(Grupo.Id)),
                    r => r.HasOne(typeof(ConsultaAlmacenada)).WithMany().HasForeignKey("Fk_ConsultaAlmacenada").HasPrincipalKey(nameof(ConsultaAlmacenada.Id)),
                    j => j.HasKey("Fk_ConsultaAlmacenada", "Fk_Grupo"));

        /*builder.HasOne(d => d.CategoriaConsulta)
        .WithMany(p => p.ConsultasAlmacenadas)
        .HasForeignKey(d => d.CategoriaConsultaId);*/
    }
}


	