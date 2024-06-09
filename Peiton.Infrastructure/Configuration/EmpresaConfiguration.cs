using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
	{
		public void Configure(EntityTypeBuilder<Empresa> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Empresa");
			builder.Property(p => p.Descripcion).HasMaxLength(150);
			builder.Property(p => p.TipoDocumento).HasMaxLength(1);
			builder.Property(p => p.Documento).HasMaxLength(50);
			builder.Property(p => p.Cuenta).HasMaxLength(50);

		}
	}
}