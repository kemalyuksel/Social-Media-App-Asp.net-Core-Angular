using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CommentsController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpPost("{id}")]
        public async Task<ActionResult<Comment>> AddComment(int id,Comment comment)
        {
            comment.AppUserId = User.GetUserId();
            comment.PostId = id;
            
            _unitOfWork.CommentRepository.AddComment(comment);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem adding the post");
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<CommentDto>> Get(int id)
        {
            return await _unitOfWork.CommentRepository.GetCommentsByPostIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetComment(id);

            _unitOfWork.CommentRepository.DeleteComment(comment);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the post");
        }



    }
}