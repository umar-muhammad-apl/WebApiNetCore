using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCorePluralSight.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        
        //public User? User { get; set; } = null!;
        public int UserId { get; set; } 

        public Post(string title, string body)
        {
            Title = title;
            Body = body;
        }


    }
}
