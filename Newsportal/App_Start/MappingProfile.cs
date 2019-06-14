using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Newsportal.Dtos;
using Newsportal.Models;

namespace Newsportal.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
        }
    }
       
}