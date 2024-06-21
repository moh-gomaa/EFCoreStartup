namespace EFCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //Add entity to database (Second Method) using navigation property.
        public Blog Blog { get; set; }
    }
}
