using System.ComponentModel.DataAnnotations;

namespace EFCore.Models
{
    public class Book
    {
        //To set primary key using data annotations.
        //[Key]
        public int BookKey { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
