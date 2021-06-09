using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using API.DTOs;

namespace API.Data
{
    public class CommentRepository : ICommentRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment){
            _context.Comments.Remove(comment);
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _context.Comments.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int id)
        {
            return await _context.Comments.Where(x => x.PostId == id).ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
    }
}