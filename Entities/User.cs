using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        //[JsonIgnore]
        public ICollection<Post> Posts { get; set;} = new List<Post>();

        //public User(string name, string username, string email, List<Post> posts)
        //{
        //    Name = name;
        //    Username = username;
        //    Email = email;
        //    Posts = posts;
        //}
        //public User(string name, string username, string email)
        //{
        //    Name = name;
        //    Username = username;
        //    Email = email;
        //}

    }
}
