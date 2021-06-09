using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [Authorize]
    public class PostsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            post.AppUserId = User.GetUserId();
            
            _unitOfWork.PostRepository.AddPost(post);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem adding the post");
        }
    
        [HttpGet("{username}")]
        public async Task<IEnumerable<PostDto>> GetPostByUsername(string username)
        {
            return await _unitOfWork.PostRepository.GetPostsByUsername(username);
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> GetPostList()
        {
            return await _unitOfWork.PostRepository.GetPostsAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = await _unitOfWork.PostRepository.GetPost(id);

             _unitOfWork.PostRepository.DeletePost(post);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the post");
        }

        
    }
}