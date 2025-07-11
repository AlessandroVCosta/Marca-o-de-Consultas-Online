using AutoMapper;
using ClinicaXPTO.DTO.ActType;
using ClinicaXPTO.DTO.AnonymousRequest;
using ClinicaXPTO.DTO.AppointmentRequest;
using ClinicaXPTO.DTO.AppointmentRequestItem;
using ClinicaXPTO.DTO.Professional;
using ClinicaXPTO.DTO.User;
using ClinicaXPTO.MODEL.Entities;

namespace ClinicaXPTO.SERVICE.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<UserAddDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserReadDto>();

            // AnonymousRequest mappings
            CreateMap<AnonymousRequestAddDto, AnonymousRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AnonymousRequestUpdateDto, AnonymousRequest>();
            CreateMap<AnonymousRequest, AnonymousRequestReadDto>();

            // ActType mappings
            CreateMap<ActTypeAddDto, ActType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ActTypeUpdateDto, ActType>();
            CreateMap<ActType, ActTypeReadDto>();

            // Professional mappings
            CreateMap<ProfessionalAddDto, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProfessionalUpdateDto, Professional>();
            CreateMap<Professional, ProfessionalReadDto>();

            // AppointmentRequest mappings
            CreateMap<AppointmentRequestAddDto, AppointmentRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.DataPedido, opt => opt.Ignore());
            CreateMap<AppointmentRequestUpdateDto, AppointmentRequest>();
            CreateMap<AppointmentRequest, AppointmentRequestReadDto>();

            // AppointmentRequestItem mappings
            CreateMap<AppointmentRequestItemAddDto, AppointmentRequestItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AppointmentRequestItemUpdateDto, AppointmentRequestItem>();
            CreateMap<AppointmentRequestItem, AppointmentRequestItemReadDto>();
        }
    }
}
