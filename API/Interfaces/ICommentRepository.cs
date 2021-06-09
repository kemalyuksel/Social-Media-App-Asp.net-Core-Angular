using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.DTOs;

namespace API.Interfaces
{
    public interface ICommentRepository
    {
         void DeleteComment(Comment comment);
         Task<Comment> GetComment(int id);
         Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int id);
         void AddComment(Comment comment);
    }
}