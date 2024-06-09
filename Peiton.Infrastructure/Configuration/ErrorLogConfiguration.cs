using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
	{
		public void Configure(EntityTypeBuilder<ErrorLog> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ErrorLog");
			builder.Property(p => p.Message).HasMaxLength(1024);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

		}
	}
}