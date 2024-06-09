using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ParentescoConfiguration : IEntityTypeConfiguration<Parentesco>
	{
		public void Configure(EntityTypeBuilder<Parentesco> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Parentesco");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}