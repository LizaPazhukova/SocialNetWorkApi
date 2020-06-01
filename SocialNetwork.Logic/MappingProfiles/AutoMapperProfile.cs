using AutoMapper;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateTwoWaysMap<Post, PostDTO>();
            CreateTwoWaysMap<Comment, CommentDTO>();
            CreateTwoWaysMap<Like, LikeDTO>();
            CreateTwoWaysMap<Request, RequestDTO>();
            CreateTwoWaysMap<Message, MessageDTO>();
            CreateTwoWaysMap<AppUser, UserDTO>();
        }

        private void CreateTwoWaysMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
