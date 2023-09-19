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
        public async Task<ActionResult> CreateUser(UserDto user)
        {
            return Ok(await _repository.CreateUserAsync(user));
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
