using AutoMapper;
using MyAccount.DTO.User;
using MyAccount.Model;

namespace MyAccount.MappingDTO
{
    public class UserMappingDTO : Profile
    {        
        public UserMappingDTO()
        {
            CreateMap<User, UserDTO>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(m => m.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(m => m.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt))
                .ForMember(m => m.DeletedAt, opt => opt.MapFrom(s => s.DeletedAt))
                .ForMember(m => m.Password, opt => opt.Ignore())
                .AfterMap((s, d) =>
                {
                    d.Password = "";
                })
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<UserDTO, User>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.UpdatedAt, opt => opt.Ignore())
                .ForMember(m => m.DeletedAt, opt => opt.Ignore())
                .ForMember(m => m.Password, opt => opt.Ignore())
                .AfterMap((s, d) =>
                {
                    if (s.Id != null)
                    {
                        d.Id = s.Id ?? 0;
                    }

                    d.SetPassword(s.Password);
                })
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}