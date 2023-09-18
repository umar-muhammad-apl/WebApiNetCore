using System.ComponentModel.DataAnnotations;

namespace AspNetCorePluralSight.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<Post> Posts { get; set;} = new List<Post>();

        public User(string name, string username, string email)
        {
            Name = name;
            Username = username;
            Email = email;
        }
        
    }
}
