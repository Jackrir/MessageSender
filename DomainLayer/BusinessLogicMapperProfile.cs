using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BusinessLogicMapperProfile : Profile
    {
        public BusinessLogicMapperProfile()
        {
            CreateMap<UserModel, User>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));
            CreateMap<Message, CreatedMessageModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Text, y => y.MapFrom(z => z.Text))
                .ForMember(x => x.Time, y => y.MapFrom(z => z.Time));
            CreateMap<Message, CreatedMessageWithUserModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Text, y => y.MapFrom(z => z.Text))
                .ForMember(x => x.Time, y => y.MapFrom(z => z.Time))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
