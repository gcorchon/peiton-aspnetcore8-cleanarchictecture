using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleFuncionarioConfiguration : IEntityTypeConfiguration<InmuebleFuncionario>
{
	public void Configure(EntityTypeBuilder<InmuebleFuncionario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_InmuebleFuncionario");
		builder.Property(p => p.Nombre).HasMaxLength(50);

	}
}
