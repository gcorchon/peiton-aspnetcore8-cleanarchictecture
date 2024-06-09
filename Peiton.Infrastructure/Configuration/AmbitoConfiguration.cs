using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AmbitoConfiguration : IEntityTypeConfiguration<Ambito>
	{
		public void Configure(EntityTypeBuilder<Ambito> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Ambito");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}