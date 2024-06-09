using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Cliente");
			builder.Property(p => p.CodCliente).HasMaxLength(50);
			builder.Property(p => p.Nombre).HasMaxLength(255);
			builder.Property(p => p.Activo).IsRequired();
			builder.Property(p => p.CIF).HasMaxLength(50);

		}
	}
}