using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class PostRepository : IPostRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddPost(Post post)
        {
            if(post.MediaUrl== null){
                post.MediaUrl ="empty";
            }

            if(post.MediaUrl.Contains("youtube")){
                string domain = "https://www.youtube.com/embed/";
                string videoName = post.MediaUrl.Substring(32,11);

                post.MediaUrl = domain+videoName;
            }   

             if(post.MediaUrl.Contains("spotify")){
                string domain = "https://open.spotify.com/embed/track/";
                string mediaName = post.MediaUrl.Substring(31,22);

                post.MediaUrl = domain+mediaName;
            } 

            _context.Posts.Add(post);
        }

        public void DeletePost(Post post){

            var postDeleted = _context.Posts.Where(x => x.Id == post.Id).Include(e => e.Comments).First();

            _context.Posts.Remove(postDeleted);
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
             return await _context.Posts
             .OrderByDescending(x => x.CreatedTime)
             .ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUsername(string username)
        {
            return await _context.Posts
            .Where(x => x.AppUser.UserName == username)
            .OrderByDescending(x => x.CreatedTime)
            .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}