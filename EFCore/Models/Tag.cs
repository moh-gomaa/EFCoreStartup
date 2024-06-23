using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    //To change table name and schema using data annotations
    //[Table("Tags", Schema = "blogging")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Post Post { get; set; }
    }
}
