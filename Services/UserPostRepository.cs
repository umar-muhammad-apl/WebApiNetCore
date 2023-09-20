using AspNetCorePluralSight.DTOs;
using AspNetCorePluralSight.Entities;
using Microsoft.AspNetCore.Mvc;
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
            List<Post> posts = new List<Post>();
            foreach (var item in userDto.Posts)
            {
                posts.Add(new Post { Title= item.Title, Body= item.Body });
            }
                User user = new User {   
                Name = userDto.Name, 
                Username = userDto.Username, 
                Email = userDto.Email, 
                Posts= posts
                };
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
            return await _context.Users.Include(c => c.Posts).ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.Where(c => c.Id == id).Include(_ => _.Posts).FirstOrDefaultAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _context.Posts.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

      
        public async Task<Post?> CreatePostAsync(int userId, PostDto newPost)
        {
            //var user = await _context.Users.FindAsync(userId);
            var user = await GetUserByIdAsync(userId);
            Post post = new Post { Title = newPost.Title, Body = newPost.Body };

            if(user != null)
            {
                user.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post;
            }
            return null;
            
        }

        
    }
}
