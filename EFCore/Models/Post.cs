using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //Add entity to database (Second Method) using navigation property.
        public Blog Blog { get; set; }

        //Ignore property from migration using data annotations.
        [NotMapped]
        public DateTime CreatedAt { get; set; }


        public List<Tag> Tags { get; set; }
    }
}
