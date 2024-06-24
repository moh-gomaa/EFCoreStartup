using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class Category
    {
        //To set generated identity column with data annotations.
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
