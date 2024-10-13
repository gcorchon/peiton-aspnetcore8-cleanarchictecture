using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SolicitanteRevisionConfiguration : IEntityTypeConfiguration<SolicitanteRevision>
{
	public void Configure(EntityTypeBuilder<SolicitanteRevision> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SolicitanteRevision");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
