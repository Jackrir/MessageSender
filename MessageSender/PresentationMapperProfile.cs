using AutoMapper;
using BusinessLogicLayer.Models;
using PresentationLayer.API.Requests;
using System.Collections.Generic;

namespace PresentationLayer
{
    public class PresentationMapperProfile : Profile
    {
        public PresentationMapperProfile()
        {
            CreateMap<LoginModelRequest, UserModel>();
            CreateMap<RegistrationModelRequest, UserModel>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));
            CreateMap<NewMessageRequest, MessageModel>();
            CreateMap<EditMessageRequest, MessageModel>();
        }
    }
}
