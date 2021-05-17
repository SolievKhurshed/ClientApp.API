using AutoMapper;
using ClientApp.API.ClientApp.Data.Entities;
using ClientApp.API.Models;

namespace ClientApp.API.Configuration
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientShortInfoModel>()
                .ForMember(
                    x => x.ClientType,
                    y => y.MapFrom(z => z.ClientType.TypeName))
                .ForMember(
                    x => x.ClientGroup,
                    y => y.MapFrom(z => z.ClientGroup.GroupName));

            CreateMap<Client, ClientFullInfoModel>()
                .ForMember(
                    x => x.ClientType,
                    y => y.MapFrom(z => z.ClientType.TypeName))
                .ForMember(
                    x => x.ClientGroup,
                    y => y.MapFrom(z => z.ClientGroup.GroupName))
                .ForMember(
                    x => x.UserFullName,
                    y => y.MapFrom(z => $"{z.User.LastName} {z.User.FirstName} {z.User.MiddleName}".Trim()));

            CreateMap<ClientUpdateDto, Client>();
        }
    }
}
