using AspNetCorePluralSight.DTOs;
using AspNetCorePluralSight.Entities;
using AspNetCorePluralSight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AspNetCorePluralSight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUserPost _repository;

        public PostsController(IUserPost repository)
        {
            _repository = repository;
        }
        
        [HttpPost("posts")]
        public async Task<ActionResult> CreatePost(int userId, PostDto newPost)
        {
            var post = await _repository.CreatePostAsync(userId, newPost);
            if(post!= null){
                return Ok(post);
            }
            return new NotFoundResult();    
        }


        [HttpGet("allposts")]
        public async Task<List<Post>> GetAllPosts()
        {
            return await _repository.GetPostsAsync();
        }

        [HttpGet("post")]
        public async Task<Post?> GetUserById(int postId)
        {
            return await _repository.GetPostByIdAsync(postId);
        }
    }
}
