using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Url { get; set; }

        //Add entity to database (Second Method) using navigation property.
        public List<Post> Posts { get; set; }

        //Exclude entity from database (First Method).
        //[NotMapped]
        public List<BlogPoint> BlogPoints { get; set; }
    }
}
