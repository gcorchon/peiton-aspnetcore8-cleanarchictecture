using AutoMapper;
using Peiton.Core.Utils;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuAppoyoProfile : Profile
{
    public TuAppoyoProfile()
    {
        CreateMap<Ent.TeAppoyo,VM.TuAppoyo.ConfiguracionViewModel>()
            .ForMember(vm => vm.Password, opt => opt.Ignore());
        
        CreateMap<VM.TuAppoyo.ConfiguracionViewModel, Ent.TeAppoyo>()
            .ForMember(e => e.Password, opt => opt.MapFrom((vm, e) => !string.IsNullOrWhiteSpace(vm.Password) ? TuAppoyoHelper.HashPassword(vm.Password) : e.Password))
            .ForMember(e => e.PasswordChange, opt => opt.MapFrom(vm => !string.IsNullOrWhiteSpace(vm.Password)))
            .ForMember(e => e.RefreshToken, opt => opt.MapFrom((vm, e) => !vm.Enabled ? null : e.RefreshToken))
            .ForMember(e => e.RefreshTokenExpirationDate, opt => opt.MapFrom((vm, e) => !vm.Enabled ? null : e.RefreshTokenExpirationDate));
    }
}