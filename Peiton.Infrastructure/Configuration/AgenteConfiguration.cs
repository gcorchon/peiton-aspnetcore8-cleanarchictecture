using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AgenteConfiguration : IEntityTypeConfiguration<Agente>
	{
		public void Configure(EntityTypeBuilder<Agente> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Agente");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.CIF).HasMaxLength(10);
			builder.Property(p => p.Domicilio).HasMaxLength(255);
			builder.Property(p => p.Telefono).HasMaxLength(9);
			builder.Property(p => p.email).HasMaxLength(255);

		}
	}
}