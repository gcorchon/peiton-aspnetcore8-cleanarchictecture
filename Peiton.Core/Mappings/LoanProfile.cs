using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<Ent.Loan, VM.Prestamos.PrestamoListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => false))
            .ForMember(vm => vm.TipoPrestamo, opt => opt.MapFrom(p => p.TipoPrestamo != null ? p.TipoPrestamo.Descripcion : null))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.Credencial.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.Inicial, opt => opt.MapFrom(p => p.InitialBalance))
            .ForMember(vm => vm.Pendiente, opt => opt.MapFrom(p => p.Debt))
            .ForMember(vm => vm.FechaSaldo, opt => opt.MapFrom(p => p.UltimaActualizacion));

        CreateMap<Ent.Loan, VM.Prestamos.PrestamoViewModel>()
            .ForMember(vm => vm.EntidadFinancieraId, opt => opt.MapFrom(p => p.Credencial.EntidadFinancieraId))
            .ForMember(vm => vm.Inicial, opt => opt.MapFrom(p => p.InitialBalance))
            .ForMember(vm => vm.Pendiente, opt => opt.MapFrom(p => p.Debt))
            .ForMember(vm => vm.FechaInicio, opt => opt.MapFrom(p => p.BeginDate))
            .ForMember(vm => vm.FechaSaldo, opt => opt.MapFrom(p => p.UltimaActualizacion))
            .ForMember(vm => vm.Numero, opt => opt.MapFrom(p => p.AccountNumber));

        CreateMap<VM.Prestamos.ActualizarPrestamoRobotRequest, Ent.Loan>();
    }
}