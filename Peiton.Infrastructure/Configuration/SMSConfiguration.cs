using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SMSConfiguration : IEntityTypeConfiguration<SMS>
{
	public void Configure(EntityTypeBuilder<SMS> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SMS");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Usado).IsRequired();

	}
}
