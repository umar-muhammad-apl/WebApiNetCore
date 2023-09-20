using AspNetCorePluralSight.DTOs;
using AspNetCorePluralSight.Entities;
using AspNetCorePluralSight.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<User>> CreateUser(UserDto user)
        {
            User createdUser = await _repository.CreateUserAsync(user);
            return Ok(createdUser);
        }
        
        [HttpGet("allusers")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetUsersAsync();
        }

        [HttpGet("user")]
        public async Task<User?> GetUserById(int userId)
        {
            return await _repository.GetUserByIdAsync(userId);
        }

        

    }
}
