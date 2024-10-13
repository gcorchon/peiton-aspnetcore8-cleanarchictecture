using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TextoEstaticoConfiguration : IEntityTypeConfiguration<TextoEstatico>
{
	public void Configure(EntityTypeBuilder<TextoEstatico> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TextoEstatico");
		builder.Property(p => p.Identificador).HasMaxLength(255);

	}
}
