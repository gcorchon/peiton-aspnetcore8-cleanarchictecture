using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleConfiguration : IEntityTypeConfiguration<Inmueble>
{
	public void Configure(EntityTypeBuilder<Inmueble> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Inmueble");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Llave).HasMaxLength(10);
		builder.Property(p => p.TipoViaId).HasColumnName("Fk_TipoVia");
		builder.Property(p => p.Numero).HasMaxLength(10);
		builder.Property(p => p.Portal).HasMaxLength(10);
		builder.Property(p => p.Escalera).HasMaxLength(10);
		builder.Property(p => p.Piso).HasMaxLength(10);
		builder.Property(p => p.Puerta).HasMaxLength(10);
		builder.Property(p => p.CodigoPostal).HasMaxLength(10);
		builder.Property(p => p.Municipio).HasMaxLength(50);
		builder.Property(p => p.Barrio).HasMaxLength(50);
		builder.Property(p => p.DistritoId).HasColumnName("Fk_Distrito");
		builder.Property(p => p.ProvinciaId).HasColumnName("Fk_Provincia");
		builder.Property(p => p.DireccionCompleta).HasComputedColumnSql("([dbo].[ObtenerDireccionCompleta]([Pk_Inmueble]))", false);
		builder.Property(p => p.RegistroCiudad).HasMaxLength(255);
		builder.Property(p => p.RegistroNumero).HasMaxLength(255);
		builder.Property(p => p.RegistroInscripcionReferencia).HasMaxLength(255);
		builder.Property(p => p.RegistroReferenciaCatastral).HasMaxLength(255);
		builder.Property(p => p.TipoInmuebleId).HasColumnName("Fk_TipoInmueble");
		builder.Property(p => p.Superficie).HasMaxLength(10);
		builder.Property(p => p.UtilizacionId).HasColumnName("Fk_Utilizacion");
		builder.Property(p => p.AgenteArrendadoId).HasColumnName("Fk_AgenteArrendado");
		builder.Property(p => p.AgenteVentaId).HasColumnName("Fk_AgenteVenta");
		builder.Property(p => p.ValoracionId).HasColumnName("Fk_Valoracion");
		builder.Property(p => p.AgenteDeshaucioId).HasColumnName("Fk_AgenteDeshaucio");
		builder.Property(p => p.AgenteHerenciaId).HasColumnName("Fk_AgenteHerencia");
		builder.Property(p => p.AgentePendienteValoracionId).HasColumnName("Fk_AgentePendienteValoracion");
		builder.Property(p => p.AgenteProcesoRegularizacionId).HasColumnName("Fk_AgenteProcesoRegularizacion");
		builder.Property(p => p.RentaEstimada).HasMaxLength(20);
		builder.Property(p => p.AgenteExtincionId).HasColumnName("Fk_AgenteExtincion");
		builder.Property(p => p.Ivima).IsRequired();
		builder.Property(p => p.AgenteCompraId).HasColumnName("Fk_AgenteCompra");
		builder.Property(p => p.AgenteProcesoCompraId).HasColumnName("Fk_AgenteProcesoCompra");
		builder.Property(p => p.InmuebleFuncionarioId).HasColumnName("Fk_InmuebleFuncionario");
		builder.Property(p => p.ImporteVenta).HasColumnType("money");
		builder.Property(p => p.ImporteExtincion).HasColumnType("money");
		builder.Property(p => p.ImporteVenta).HasColumnType("money");
		builder.Property(p => p.ImporteAdquisicion).HasColumnType("money");
		builder.Property(p => p.ImporteCompra).HasColumnType("money");
		/*builder.HasOne(d => d.AgenteDeshaucio)
			.WithMany(p => p.InmueblesAgenteDeshaucio)
			.HasForeignKey(d => d.AgenteDeshaucioId);*/

		/*builder.HasOne(d => d.AgenteArrendado)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.AgenteArrendadoId);*/

		/*builder.HasOne(d => d.AgenteVenta)
			.WithMany(p => p.InmueblesAgenteVenta)
			.HasForeignKey(d => d.AgenteVentaId);*/

		/*builder.HasOne(d => d.AgenteHerencia)
			.WithMany(p => p.InmueblesAgenteHerencia)
			.HasForeignKey(d => d.AgenteHerenciaId);*/

		/*builder.HasOne(d => d.AgentePendienteValoracion)
			.WithMany(p => p.InmueblesAgentePendienteValoracion)
			.HasForeignKey(d => d.AgentePendienteValoracionId);*/

		/*builder.HasOne(d => d.AgenteProcesoRegularizacion)
			.WithMany(p => p.InmueblesAgenteProcesoRegularizacion)
			.HasForeignKey(d => d.AgenteProcesoRegularizacionId);*/

		/*builder.HasOne(d => d.Distrito)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.DistritoId);*/

		/*builder.HasOne(d => d.InmuebleFuncionario)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.InmuebleFuncionarioId);*/

		/*builder.HasOne(d => d.Provincia)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.ProvinciaId);*/

		/*builder.HasOne(d => d.TipoInmueble)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.TipoInmuebleId);*/

		/*builder.HasOne(d => d.TipoVia)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.TipoViaId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Utilizacion)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.UtilizacionId);*/

		/*builder.HasOne(d => d.Valoracion)
			.WithMany(p => p.Inmuebles)
			.HasForeignKey(d => d.ValoracionId);*/

	}
}
