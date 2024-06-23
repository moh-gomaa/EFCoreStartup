using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    //To change table name using data annotations
    //[Table("BlogPoints")]
    public class BlogPoint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }

        public Blog Blog { get; set; }
    }
}
