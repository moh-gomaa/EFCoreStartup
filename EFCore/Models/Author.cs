using System.ComponentModel.DataAnnotations;

namespace EFCore.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        //This is computed column
        [MaxLength(200)]
        public string? DisplayName { get; set; }
    }
}
