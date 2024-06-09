using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EntidadFinancieraConfiguration : IEntityTypeConfiguration<EntidadFinanciera>
	{
		public void Configure(EntityTypeBuilder<EntidadFinanciera> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_EntidadFinanciera");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.Codigo).HasMaxLength(4);
			builder.Property(p => p.EurobitsID).HasMaxLength(50);
			builder.Property(p => p.Productos).HasMaxLength(255).IsRequired().HasDefaultValueSql("(N'Accounts,Deposits,Funds,Shares,Loans')");
			builder.Property(p => p.Campos).HasMaxLength(255).HasDefaultValueSql("(N'dni:DNI|user:Usuario|password:Contraseña')");
			builder.Property(p => p.FormatString).HasMaxLength(255).HasDefaultValueSql("(N'dni:{0}|user:{1}|password:{2}')");
			builder.Property(p => p.CssClass).HasMaxLength(50);
			builder.Property(p => p.Robot).IsRequired();
			builder.Property(p => p.SMSRegex).HasMaxLength(255);
			builder.Property(p => p.Dias).IsRequired();
			builder.Property(p => p.AfterbanksID).HasMaxLength(50);
			builder.Property(p => p.AfterbanksFieldsMapping).HasMaxLength(255);

		}
	}
}