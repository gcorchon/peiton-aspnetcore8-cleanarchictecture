using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TeAppoyoConfiguration : IEntityTypeConfiguration<TeAppoyo>
{
	public void Configure(EntityTypeBuilder<TeAppoyo> builder)
	{
		builder.HasKey(t => t.TuteladoId);

		builder.Property(p => p.TuteladoId).ValueGeneratedNever().HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Username).HasMaxLength(255);
		builder.Property(p => p.Password).HasMaxLength(255);
		builder.Property(p => p.RefreshToken).HasMaxLength(255);
		builder.Property(p => p.PasswordChange).IsRequired();

		builder.HasOne(d => d.Tutelado)
			.WithOne(p => p.TeAppoyo)
			.HasForeignKey<TeAppoyo>(t => t.TuteladoId);

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.TeAppoyos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
