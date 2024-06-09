using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CompaniaConfiguration : IEntityTypeConfiguration<Compania>
	{
		public void Configure(EntityTypeBuilder<Compania> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Compania");
			builder.Property(p => p.Descripcion).HasMaxLength(30);

		}
	}
}