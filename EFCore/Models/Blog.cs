using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }

        //To rename column using data annotations.
        //[Column("BlogName")]
        public string Name { get; set; }

        //To rename column and change data type using data annotations.
        //[Column("BlogUrl", TypeName = "varchar(250)")]
        //To add comment using data annotations.
        [Comment("The url of the blog")]
        public string? Url { get; set; }

        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        //Add entity to database (Second Method) using navigation property.
        public List<Post> Posts { get; set; }

        //Exclude entity from database (First Method).
        //[NotMapped]
        public List<BlogPoint> BlogPoints { get; set; }
    }
}
