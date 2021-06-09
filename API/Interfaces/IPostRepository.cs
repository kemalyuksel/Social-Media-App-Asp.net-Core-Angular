using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.DTOs;

namespace API.Interfaces
{
    public interface IPostRepository
    {
         void DeletePost(Post post);
         Task<Post> GetPost(int id);
         Task<IEnumerable<PostDto>> GetPostsAsync();
         void AddPost(Post post);
         Task<IEnumerable<PostDto>> GetPostsByUsername(string username);
    }
}