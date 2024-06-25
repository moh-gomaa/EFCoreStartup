using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    //There is a one-to-many relationsip between ApartmentOwners table & Apartments table.
    //ApartmentOwner is a child (dependant) entity which should contatin a foreign key and Apartment is a parent (principal) entity.
    public class ApartmentOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CivilId { get; set; }

        public int ApartmentKey { get; set; }

        //To apply one-to-many relationship with data annotations with custom foreign key name.
        //[ForeignKey("ApartmentKey")]
        public Apartment Apartment { get; set; }
    }
}
