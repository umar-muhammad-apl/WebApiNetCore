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
    public class UsersController : ControllerBase
    {
        private readonly IUserPost _repository;

        public UsersController(IUserPost repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto user)
        {
            return Ok(await _repository.CreateUserAsync(user));
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

        [HttpGet("allusers")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetUsersAsync();
        }

        [HttpGet("allposts")]
        public async Task<List<Post>> GetAllPosts()
        {
            return await _repository.GetPostsAsync();
        }

    }
}
