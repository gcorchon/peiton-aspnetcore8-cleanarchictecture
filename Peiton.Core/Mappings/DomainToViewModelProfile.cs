﻿using AutoMapper;

using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;
using Peiton.Serialization;

namespace Peiton.Core.Mappings
{
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
        }
    }
}