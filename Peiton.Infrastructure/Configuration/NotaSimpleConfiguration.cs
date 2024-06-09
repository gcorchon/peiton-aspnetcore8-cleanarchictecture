using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class NotaSimpleConfiguration : IEntityTypeConfiguration<NotaSimple>
	{
		public void Configure(EntityTypeBuilder<NotaSimple> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_NotaSimple");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.CausaNotaSimpleId).HasColumnName("Fk_CausaNotaSimple");
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Finalizado).IsRequired();
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");

			/*builder.HasOne(d => d.Inmueble)
				.WithMany(p => p.NotasSimples)
				.HasForeignKey(d => d.InmuebleId);*/

			/*builder.HasOne(d => d.CausaNotaSimple)
				.WithMany(p => p.NotasSimples)
				.HasForeignKey(d => d.CausaNotaSimpleId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.NotasSimples)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.NotasSimples)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}