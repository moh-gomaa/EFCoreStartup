namespace EFCore.Models
{
    public class BlogPoint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }

        public Blog Blog { get; set; }
    }
}
