namespace AspNetCorePluralSight.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public UserDto(string name, string username, string email)
        {
            Name = name;
            Username = username;
            Email = email;
        }
    }
}
