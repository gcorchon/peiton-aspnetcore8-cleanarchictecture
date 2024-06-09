using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class QuejaTipoDenuncianteConfiguration : IEntityTypeConfiguration<QuejaTipoDenunciante>
	{
		public void Configure(EntityTypeBuilder<QuejaTipoDenunciante> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_QuejaTipoDenunciante");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}