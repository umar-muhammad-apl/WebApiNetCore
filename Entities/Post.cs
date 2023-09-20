using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AspNetCorePluralSight.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public User User { get; set; } 
        public int UserId { get; set; } 

        //public Post(string title, string body)
        //{
        //    Title = title;
        //    Body = body;
        //}


    }
}
