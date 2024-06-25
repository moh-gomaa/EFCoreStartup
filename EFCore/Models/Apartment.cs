namespace EFCore.Models
{
    //There is a one-to-many relationsip between Apartments table & ApartmentOwners table.
    //Apartment is a parent (principal) entity and ApartmentOwner is a child (dependant) entity which should contain a foreign key.
    public class Apartment
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //This is computed field (Width * Height).
        public int? Size { get; set; }

        public List<ApartmentOwner> ApartmentOwner { get; set; }
    }
}
