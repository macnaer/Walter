using AutoMapper;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Post;
using Walter.Core.Entities.Site;
using Walter.Core.Entities.Specifications;
using Walter.Core.Interfaces;

namespace Walter.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Post> _postRepo;

        public PostService(IRepository<Post> postRepo, IMapper mapper)
        {
            _mapper = mapper;
            _postRepo = postRepo;
        }
        public async Task<PostDto?> Get(int id)
        {
            if (id < 0) return null; // exception handling

            var post = await _postRepo.GetByID(id);

            if (post == null) return null; // exception handling

            return _mapper.Map<PostDto>(post);
        }

        public async Task<List<PostDto>> GetByCategory(int id)
        {
            var result = await _postRepo.GetListBySpec(new Posts.ByCategory(id));
            return _mapper.Map<List<PostDto>>(result);
        }
    }
}
