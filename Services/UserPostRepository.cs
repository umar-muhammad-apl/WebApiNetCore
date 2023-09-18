using AspNetCorePluralSight.DTOs;
using AspNetCorePluralSight.Entities;
using Microsoft.EntityFrameworkCore;
using WebApiAspNet7Patrick.Data;

namespace AspNetCorePluralSight.Services
{
    public class UserPostRepository : IUserPost
    {
        private readonly DataContext _context;

        public UserPostRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            User user = new(userDto.Name, userDto.Username, userDto.Email);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUsersByIdAsync(int id)
        {
            return await _context.Users.Include(_ => _.Posts).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

      

        public async Task<Post?> CreatePostAsync(int userId, PostDto newPost)
        {
            var user = await GetUsersByIdAsync(userId);
            Post post = new(newPost.Title, newPost.Body);

            if(user != null)
            {
                user.Posts.Add(post);
                return post;
            }
            return null;
            
        }
    }
}
