using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        IMessageRepository MessageRepository {get;}
        ILikesRepository LikesRepository {get; }
        IPostRepository PostRepository {get; }
        ICommentRepository CommentRepository {get; }
        
        Task<bool> Complete();
        bool HasChanges();
    }
}