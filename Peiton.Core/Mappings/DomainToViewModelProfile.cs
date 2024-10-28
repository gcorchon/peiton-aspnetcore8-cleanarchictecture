using System.Xml.Linq;
using AutoMapper;
using Peiton.Core.Entities;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DomainToViewModelProfile : Profile
{

    public DomainToViewModelProfile()
    {
        CreateMap<Ent.Tutelado, VM.Tutelado.Response.TuteladoViewModel>();
        CreateMap<Ent.AnoPresupuestario, VM.AnoPresupuestario.AnoPresupuestarioViewModel>();
        CreateMap<Ent.AccountTransactionCP, VM.MovimientosPendientesBanco.MovimientoPendienteBancoListItem>()
            .ForMember(vm => vm.AccountCPName, opt => opt.MapFrom(obj => obj.AccountCP.WebAlias));
        CreateMap<Ent.AccountTransactionCP, VM.MovimientosPendientesBanco.MovimientoPendienteBancoViewModel>()
            .ForMember(vm => vm.WebAlias, opt => opt.MapFrom(obj => obj.AccountCP.WebAlias))
            .ForMember(vm => vm.Iban, opt => opt.MapFrom(obj => obj.AccountCP.Iban));

        CreateMap<Ent.Tutelado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(obj => obj.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(obj => obj.Nombre + " " + obj.Apellidos));

        CreateMap<Ent.Cliente, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(obj => obj.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(obj => obj.Nombre));

        CreateMap<Ent.Asiento, VM.Asientos.AsientoViewModel>()
            .ForMember(vm => vm.CapituloId, opt => opt.MapFrom(obj => obj.Partida != null ? obj.Partida.CapituloId : (int?)null))
            .ForMember(vm => vm.FacturaIds, opt => opt.MapFrom(obj => obj.Facturas.Select(f => f.Id)));

        CreateMap<Ent.Factura, VM.Facturas.FacturaViewModel>();

        CreateMap<Ent.Factura, VM.Facturas.FacturaListItem>()
            .ForMember(vm => vm.EstadoInicial, opt => opt.MapFrom(obj => obj.EstadoInicial.HasValue ? VM.Facturas.EstadoFactura.GetText(obj.EstadoInicial.Value) : null))
            .ForMember(vm => vm.EstadoContable, opt => opt.MapFrom(obj => obj.EstadoContable.HasValue ? VM.Facturas.EstadoFactura.GetText(obj.EstadoContable.Value) : null));

        CreateMap<Ent.Asiento, VM.Asientos.AsientoHuerfanoListItem>()
            .ForMember(vm => vm.Partida, opt => opt.MapFrom(obj => obj.Partida!.Numero))
            .ForMember(vm => vm.Capitulo, opt => opt.MapFrom(obj => obj.Partida!.Capitulo!.Numero));

        CreateMap<Ent.Asiento, VM.Asientos.AsientoListItem>()
            .ForMember(vm => vm.Partida, opt => opt.MapFrom(obj => obj.Partida!.Numero))
            .ForMember(vm => vm.Capitulo, opt => opt.MapFrom(obj => obj.Partida!.Capitulo!.Numero))
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.CajaAMTAId != null ? "C" : (obj.AccountTransactionCPId != null ? "B" : "")))
            .ForMember(vm => vm.IngresoGasto, opt => opt.MapFrom(obj => obj.TipoMovimiento == 1 ? "G" : "I"));

        CreateMap<Ent.CajaAMTA, VM.MovimientosPendientesCaja.MovimientoPendienteCajaListItem>()
            .ForMember(vm => vm.Persona, opt => opt.MapFrom(obj => !string.IsNullOrWhiteSpace(obj.Persona) ? obj.Persona : (obj.Tutelado != null ? obj.Tutelado.NombreCompleto : "")));

        CreateMap<Ent.CajaAMTA, VM.MovimientosPendientesCaja.MovimientoPendienteCajaViewModel>();

        CreateMap<Ent.Vale, VM.Vales.ValeViewModel>();
        CreateMap<Ent.Vale, VM.Vales.ValeListItem>()
                .ForMember(vm => vm.Solicitante, m => m.MapFrom(t => t.Solicitante.NombreCompleto));

        CreateMap<Ent.Vale, VM.Vales.ValeViewModel>()
           .ForMember(vm => vm.Solicitante, m => m.MapFrom(t => t.Solicitante.NombreCompleto))
           .ForMember(vm => vm.Revisor, m => m.MapFrom(t => t.Revisor != null ? t.Revisor.NombreCompleto : null))
           .ForMember(vm => vm.Autorizador, m => m.MapFrom(t => t.Autorizador != null ? t.Autorizador.NombreCompleto : null))
           .ForMember(vm => vm.Archivos, m => m.MapFrom(t => t.Archivos != null ? t.Archivos.Deserialize<string[]>() : new string[] { }));

        CreateMap<Ent.Cliente, VM.Clientes.ClienteListItem>();

        CreateMap<Ent.Caja, VM.Caja.CajaViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto));

        CreateMap<Ent.Caja, VM.Caja.CajaListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(obj => obj.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.TipoPago != null ? obj.TipoPago.Descripcion : null))
            .ForMember(vm => vm.TuteladoMuerto, opt => opt.MapFrom(obj => obj.Tutelado.Muerto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(obj => obj.Pendiente ? "Pendiente" : "Pagado"));

        CreateMap<Ent.Caja, VM.Caja.HistoricoMovimientoListItem>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.TipoPago != null ? obj.TipoPago.Descripcion : null))
            .ForMember(vm => vm.Metodo, opt => opt.MapFrom(obj => obj.MetodoPago != null ? obj.MetodoPago.Descripcion : null));

        CreateMap<Ent.VwCajaAMTA, VM.Caja.CajaAMTAListItem>()
            .ForMember(vm => vm.PersonaReceptora, m => m.MapFrom(o => o.Persona ?? o.Tutelado!.NombreCompleto));

        /*CreateMap<Ent.Account, VM.Account.AccountViewModel>();
        CreateMap<Ent.EntidadFinanciera, VM.EntidadFinanciera.EntidadFinancieraViewModel>()
            .ForMember(vm => vm.Accounts, opt => opt.MapFrom(e => e.Credenciales.SelectMany(c => c.Accounts)));*/

        CreateMap<Ent.CajaIncidencia, VM.Caja.IncidenciaListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(obj => obj.Tutelado.NombreCompleto))
            .ForMember(vm => vm.RazonIncidencia, opt => opt.MapFrom(obj => obj.RazonIncidenciaCaja.Descripcion));

        CreateMap<Ent.CajaIncidencia, VM.Caja.IncidenciaViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto));

        CreateMap<Ent.Caja, Ent.CajaIncidencia>()
            .ForMember(vm => vm.Id, opt => opt.Ignore())
            .ForMember(vm => vm.CajaId, opt => opt.MapFrom(c => c.Id));

        CreateMap<Ent.Tutelado, VM.Caja.TuteladoReintegro>()
            .ForMember(vm => vm.Cuentas, opt => opt.MapFrom(t => t.Credenciales.SelectMany(c => c.Accounts)));

        CreateMap<Ent.Account, VM.Caja.Cuenta>();

        CreateMap<Ent.Credencial, VM.Bancos.CredencialBloquedaListItem>()
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(c => c.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(c => c.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(c => c.Tutelado.DNI))
            .ForMember(vm => vm.NumeroExpediente, opt => opt.MapFrom(c => c.Tutelado.NumeroExpediente))
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(c => c.Tutelado.DatosJuridicos != null && c.Tutelado.DatosJuridicos.Nombramiento != null ? c.Tutelado.DatosJuridicos.Nombramiento.Descripcion : null));

        CreateMap<Ent.ConsultaAlmacenada, VM.Consultas.ConsultaViewModel>()
            .ForMember(vm => vm.CategoriaId, opt => opt.MapFrom(c => c.CategoriaConsultaId))
            .ForMember(vm => vm.Usuarios, opt => opt.MapFrom(c => c.Grupos.Select(g => new VM.Usuarios.UsuarioTipo() { Tipo = 2, Id = g.Id, Nombre = g.Descripcion })
                                                                   .Concat(c.Usuarios.Select(u => new VM.Usuarios.UsuarioTipo() { Tipo = 1, Id = u.Id, Nombre = u.NombreCompleto }))

            ));

        CreateMap<Ent.AvisoTributario, VM.AvisosTributarios.AvisoTributarioViewModel>()
            .ForMember(vm => vm.TipoAvisoTributario, opt => opt.MapFrom(c => c.TipoAvisoTributario.Descripcion))
            .ForMember(vm => vm.Inmueble, opt => opt.MapFrom(c => c.Inmueble != null ? c.Inmueble.DireccionCompleta : null));

        CreateMap<Ent.AvisoTributario, VM.AvisosTributarios.AvisoTributarioListItem>()
            .ForMember(vm => vm.TipoAvisoTributario, opt => opt.MapFrom(c => c.TipoAvisoTributario.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(c => c.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(c => c.Resuelto ? "Resuelto" : (c.EnTramite ? "En trámite" : "Pendiente")));

        CreateMap<Ent.InmuebleAviso, VM.Inmuebles.InmuebleAvisoListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(c => c.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(c => c.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.TipoAviso, opt => opt.MapFrom(a => a.InmuebleTiposAvisos.Any() ? a.InmuebleTiposAvisos.First().TipoAviso.Descripcion : null))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Resuelto ? "Finalizado" : a.FechaFinalizacion.HasValue ? "Pendiente de pago" : a.EnTramite ? "En trámite" : "Pendiente"));

        CreateMap<Ent.InmuebleAviso, VM.Inmuebles.InmuebleAvisoViewModel>()
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(c => c.Usuario.NombreCompleto))
            .ForMember(vm => vm.Ocupacion, opt => opt.MapFrom(c => c.Ocupacion != null ? c.Ocupacion.Descripcion : null))
            .ForMember(vm => vm.TiposAviso, opt => opt.MapFrom(c => c.InmuebleTiposAvisos))
            .ForMember(vm => vm.Costes, opt => opt.MapFrom(c => c.InmuebleAvisosCostes));

        CreateMap<Ent.InmuebleAviso, VM.Inmuebles.InmuebleAvisoListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.Firma))
            .ForMember(vm => vm.TipoAviso, opt => opt.MapFrom(a => a.InmuebleTiposAvisos.Any() ? a.InmuebleTiposAvisos.First().TipoAviso.Descripcion : null))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Resuelto ? "Finalizado" : a.FechaFinalizacion.HasValue ? "Pendiente de pago" : a.EnTramite ? "En trámite" : "Pendiente"));

        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleInfo>();

        CreateMap<Ent.Tutelado, VM.Inmuebles.TuteladoAvisoInmueble>()
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(c => c.DatosJuridicos != null && c.DatosJuridicos.Nombramiento != null ? c.DatosJuridicos.Nombramiento.Descripcion : null))
            .ForMember(vm => vm.SegurosHogar, opt => opt.MapFrom(c => c.SegurosContratados.Where(s => s.TipoSeguroId == 2)));

        CreateMap<Ent.SeguroContratado, VM.Inmuebles.SeguroHogar>()
            .ForMember(vm => vm.TipoSeguro, opt => opt.MapFrom(c => c.TipoSeguro != null ? c.TipoSeguro.Descripcion : null))
            .ForMember(vm => vm.Seguro, opt => opt.MapFrom(c => c.Seguro != null ? c.Seguro.Descripcion : null));


        CreateMap<Ent.InmuebleTipoAviso, VM.Inmuebles.TipoAviso>()
            .ForMember(vm => vm.Descripcion, opt => opt.MapFrom(c => c.TipoAviso.Descripcion))
            .ForMember(vm => vm.Importe, opt => opt.MapFrom(c => c.Importe ?? c.TipoAviso.Importe));

        CreateMap<Ent.InmuebleAvisoCoste, VM.Inmuebles.Coste>();

        CreateMap<Ent.InmuebleAutorizacion, VM.Inmuebles.InmuebleAutorizacionListItem>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(vm => vm.TipoAviso, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.InmuebleTipoAutorizacion.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.Firma))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Presentado ? "Presentado" : (a.Autorizado ? "Autorizado" : "Pendiente"))));

        CreateMap<Ent.InmuebleAutorizacion, VM.Inmuebles.InmuebleAutorizacionViewModel>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.InmuebleTipoAutorizacion.Descripcion))
            .ForMember(vm => vm.Motivo, opt => opt.MapFrom(a => a.InmuebleMotivoAutorizacion.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(a => a.Inmueble.Tutelado.DNI));

        CreateMap<Ent.InmuebleSolicitudAlquilerVenta, VM.Inmuebles.InmuebleSolicitudAlquilerVentaListItem>()
            .ForMember(vm => vm.Direccion, opt => opt.MapFrom(s => s.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(s => s.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(s => s.Estado == 1 ? "Pendiente" : (s.Estado == 2 ? "En trámite" : s.Estado == 3 ? "Finalizado" : null)));

        CreateMap<Ent.InmuebleSolicitudAlquilerVenta, VM.Inmuebles.InmuebleSolicitudAlquilerVentaViewModel>()
            .ForMember(vm => vm.Ocupacion, opt => opt.MapFrom(a => a.Ocupacion != null ? a.Ocupacion.Descripcion : null))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario != null ? a.Usuario.NombreCompleto : null));

        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleSolicitudAlquilerVentaInfo>();
        CreateMap<Ent.Tutelado, VM.Inmuebles.TuteladoSolicitudAlquilerVenta>();

        CreateMap<Ent.NotaSimple, VM.Inmuebles.NotaSimpleListItem>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(vm => vm.Causa, opt => opt.MapFrom(a => a.CausaNotaSimple.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario != null ? a.Usuario.NombreCompleto : null))
            .ForMember(vm => vm.Texto, opt => opt.MapFrom(a => a.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble != null ? a.Inmueble.DireccionCompleta : null))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Finalizado ? "Finalizado" : "Pendiente"));


        CreateMap<Ent.Sucesion, VM.Inmuebles.SucesionListItem>()
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(o => o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(o => o.Usuario.NombreCompleto))
            .ForMember(vm => vm.TipoSucesion, opt => opt.MapFrom(o => o.SucesionTipo.Descripcion))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Autorizada ? "Autorizada" : (a.Solicitada ? "Solicitada" : "Pendiente"))));


        CreateMap<Ent.Sucesion, VM.Inmuebles.SucesionViewModel>()
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(o => o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.DNI, opt => opt.MapFrom(o => o.Tutelado.DNI))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(o => o.Usuario.NombreCompleto))
            .ForMember(vm => vm.TipoSucesion, opt => opt.MapFrom(o => o.SucesionTipo.Descripcion))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Firme" : (a.Autorizada ? "Autorizada" : (a.Solicitada ? "Solicitada" : "Pendiente"))));


        CreateMap<Ent.InmuebleTasacion, VM.Inmuebles.InmuebleTasacionListItem>()
           .ForMember(vm => vm.Id, opt => opt.MapFrom(a => a.Id))
           .ForMember(vm => vm.TipoTasacion, opt => opt.MapFrom(a => a.InmuebleTipoTasacion.Descripcion))
           .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.Firma))
           .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
           .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
           .ForMember(vm => vm.Estado, opt => opt.MapFrom(a => a.Firme ? "Finalizada" : (a.Autorizado ? "Autorizada" : (a.Presentado ? "Solicitada" : "Pendiente"))));

        CreateMap<Ent.InmuebleTasacion, VM.Inmuebles.InmuebleTasacionViewModel>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(a => a.InmuebleTipoTasacion.Descripcion))
            .ForMember(vm => vm.Trabajador, opt => opt.MapFrom(a => a.Usuario.NombreCompleto))
            .ForMember(vm => vm.DireccionCompleta, opt => opt.MapFrom(a => a.Inmueble.DireccionCompleta))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(a => a.Inmueble.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(a => a.Inmueble.Tutelado.DNI));

        CreateMap<Ent.Categoria, VM.Categorias.CategoriaViewModel>();

        CreateMap<Ent.VwCategoria, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(o => o.BreadCrumb));

        CreateMap<Ent.Company, VM.Companies.CompanyViewModel>()
            .ForMember(vm => vm.DescripcionCnae2009, opt => opt.MapFrom(o => o.Cnae2009Navigation.Description))
            .ForMember(vm => vm.Categoria, opt => opt.MapFrom(o => o.Cnae2009Navigation.Categoria != null ? o.Cnae2009Navigation.Categoria.Descripcion : null));

        CreateMap<GestionAdministrativa, VM.GestoresAdministrativos.GestionAdministrativaListItem>()
            .ForMember(vm => vm.Tutelado, m => m.MapFrom(o => o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Trabajador, m => m.MapFrom(o => o.Usuario.NombreCompleto))
            .ForMember(vm => vm.Tipo, m => m.MapFrom(o => o.GestionAdministrativaTipo.Descripcion))
            .ForMember(vm => vm.Estado, m => m.MapFrom(o => this.GetDescripcionEstadoGestionAdministrativa(o.Estado)));

        CreateMap<GestionAdministrativa, VM.GestoresAdministrativos.GestionAdministrativaViewModel>()
            .ForMember(vm => vm.Solicitada, m => m.MapFrom(o => (o.Estado & 2) > 0))
            .ForMember(vm => vm.Designada, m => m.MapFrom(o => (o.Estado & 4) > 0))
            .ForMember(vm => vm.Finalizada, m => m.MapFrom(o => (o.Estado & 8) > 0));

        CreateMap<GestionAdministrativaTipo, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Descripcion));

        CreateMap<GestorAdministrativo, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Nombre + " " + o.Apellidos));

        CreateMap<Ausencia, VM.Ausencias.AusenciaViewModel>();

        CreateMap<Usuario, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.NombreCompleto));

        CreateMap<Juzgado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Descripcion));

        CreateMap<Abogado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Nombre));

        CreateMap<Tutelado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.NombreCompleto));

        CreateMap<Queja, VM.Quejas.QuejaViewModel>()
            .ForMember(vm => vm.QuejaMotivos, m => m.MapFrom(o => o.QuejasMotivos.Select(t => t.Id).ToArray()));

        CreateMap<Queja, VM.Quejas.QuejaListItem>()
            .ForMember(vm => vm.Denunciante, m => m.MapFrom(o => o.NombreDenunciante ?? o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.TipoDenunciante, m => m.MapFrom(o => o.QuejaTipoDenunciante.Descripcion));

        CreateMap<VehiculoEntidad, VM.VehiculosEntidad.VehiculoEntidadViewModel>()
            .ForMember(vm => vm.Descripcion, opt => opt.MapFrom(u => string.Format("{0} - {1} {2} - {3} - {4}", u.Matricula, u.Marca, u.Modelo, u.Color, u.Combustible)));

        CreateMap<VehiculoEntidadReserva, VM.VehiculosEntidad.VehiculoEntidadReservaViewModel>()
            .ForMember(r => r.Propia, opt => opt.MapFrom((src, dest, destMember, context) => (int)context.Items["UserId"] == src.UsuarioId))
            .ForMember(r => r.Usuario, opt => opt.MapFrom(v => v.Usuario.NombreCompleto));

        CreateMap<RegistroEntrada, VM.Visitas.RegistroEntradaListItem>()
            .ForMember(r => r.Visitante, opt => opt.MapFrom(o => o.Nombre))
            .ForMember(r => r.Visitado, opt => opt.MapFrom(o => GetVisitantePrincipal(o.Personas)));

        CreateMap<RegistroEntrada, VM.Visitas.RegistroEntradaViewModel>()
            .ForMember(r => r.Visitante, opt => opt.MapFrom(o => new VM.Visitas.Visitante() { Dni = o.Dni, Nombre = o.Nombre, Tutelado = o.Tutelado }))
            .ForMember(r => r.Visitadas, opt => opt.MapFrom(o => GetVisitadas(o.Personas)));

        CreateMap<Sala, VM.Common.ListItem>()
            .ForMember(s => s.Value, opt => opt.MapFrom(s => s.Id))
            .ForMember(s => s.Text, opt => opt.MapFrom(s => s.Descripcion));

        CreateMap<SalaReserva, VM.Salas.ReservaViewModel>()
            .ForMember(r => r.Propia, opt => opt.MapFrom((src, dest, destMember, context) => (int)context.Items["UserId"] == src.UsuarioId))
            .ForMember(s => s.Usuario, opt => opt.MapFrom(s => s.Usuario.NombreCompleto));

        CreateMap<Senalamiento, VM.Senalamientos.SenalamientoListItem>()
            //.ForMember(s => s.Fecha, opt => opt.MapFrom(o => o.Fecha!.Value.Date))
            //.ForMember(s => s.Hora, opt => opt.MapFrom(o => o.Fecha!.Value.ToString("HH:mm")))
            .ForMember(s => s.Asistente, opt => opt.MapFrom(o => o.AbogadoAsistente != null ? o.AbogadoAsistente!.Nombre : o.ProfesionalAsistente));

        CreateMap<Senalamiento, VM.Senalamientos.SenalamientoViewModel>();
        CreateMap<Centro, VM.Centros.CentroListItem>();

        CreateMap<Centro, VM.Centros.CentroViewModel>();

        CreateMap<Sala, VM.Salas.SalaListItem>();
    }

    private string GetDescripcionEstadoGestionAdministrativa(int estado)
    {
        if ((estado & 8) > 0) return "Finalizada";
        if ((estado & 4) > 0) return "Designada";
        if ((estado & 2) > 0) return "Solicitada";
        if ((estado & 1) > 0) return "Pendiente";
        return "Pendiente";
    }

    private string? GetVisitantePrincipal(string personas)
    {
        var doc = XDocument.Parse(personas);
        var visitantes = doc.Root!.Elements("Visitado").Select(v => v.Element("Nombre")!.Value);

        var total = visitantes.Count();
        if (total > 0)
        {
            var principal = visitantes.First();
            return total > 1 ? $"{principal} (+ {total - 1})" : principal;
        }

        return null;
    }

    private VM.Visitas.Visitado[] GetVisitadas(string personas)
    {
        var doc = XDocument.Parse(personas);
        var visitantes = doc.Root!.Elements("Visitado").Select(v => new VM.Visitas.Visitado() { Nombre = v.Element("Nombre")!.Value });
        return visitantes.ToArray();
    }

}
