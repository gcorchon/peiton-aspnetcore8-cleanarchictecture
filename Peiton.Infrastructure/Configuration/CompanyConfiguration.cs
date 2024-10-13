using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Company");
		builder.Property(p => p.CIF).HasMaxLength(4);
		builder.Property(p => p.RZS).HasMaxLength(255);
		builder.Property(p => p.Cnae2009).HasMaxLength(2);
		builder.Property(p => p.CodSchober).HasMaxLength(2);

		builder.HasOne(d => d.Cnae2009Navigation)
			.WithMany(p => p.Companies)
			.HasForeignKey(d => d.Cnae2009);

		builder.HasOne(d => d.CodSchoberNavigation)
			.WithMany(p => p.Companies)
			.HasForeignKey(d => d.CodSchober);

	}
}
