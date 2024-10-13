using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EntidadDerivanteConfiguration : IEntityTypeConfiguration<EntidadDerivante>
{
	public void Configure(EntityTypeBuilder<EntidadDerivante> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_EntidadDerivante");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
