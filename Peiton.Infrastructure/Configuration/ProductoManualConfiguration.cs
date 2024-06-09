using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ProductoManualConfiguration : IEntityTypeConfiguration<ProductoManual>
	{
		public void Configure(EntityTypeBuilder<ProductoManual> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ProductoManual");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
			builder.Property(p => p.TipoProductoId).HasColumnName("Fk_TipoProducto");
			builder.Property(p => p.Nombre).HasMaxLength(255);
			builder.Property(p => p.Identificacion).HasMaxLength(50);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Titularidad).HasMaxLength(10);
			builder.Property(p => p.CustomWebAlias).HasMaxLength(255);
			builder.Property(p => p.Saldo).HasColumnType("money");
			/*builder.HasOne(d => d.EntidadFinanciera)
				.WithMany(p => p.ProductosManuales)
				.HasForeignKey(d => d.EntidadFinancieraId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.ProductosManuales)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.TipoProducto)
				.WithMany(p => p.ProductosManuales)
				.HasForeignKey(d => d.TipoProductoId);*/

		}
	}
}