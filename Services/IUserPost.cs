﻿using AspNetCorePluralSight.DTOs;
using AspNetCorePluralSight.Entities;

namespace AspNetCorePluralSight.Services
{
    public interface IUserPost
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUsersByIdAsync(int userId);
        Task<List<Post>> GetPostsAsync();

        Task<User> CreateUserAsync(UserDto newUser);
        //Task<Post?> CreatePostAsync(int userId, Post newPost);
        Task<Post?> CreatePostAsync(int cityId, PostDto newPost);
    }
}
