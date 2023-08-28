using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Post;
using Walter.Core.Entities.Site;

namespace Walter.Core.AutoMapper.Posts
{
    public class AutoMapperPostProfile : Profile
    {
        public AutoMapperPostProfile()
        {
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
