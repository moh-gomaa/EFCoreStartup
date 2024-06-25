using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    //There is a one-to-one relationsip between BlogImages table & Blogs table
    //BlogImage is a child (dependant) entity that mean we can't found BlogImage row without Blog row.
    //Otherwise we can found Blog row without BlogImage row.
    //Dependant entity (child entity) must have the foreign key.
    public class BlogImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Caption { get; set; }

        public int BlogForeignKey { get; set; }

        //To set foriegn key and change the default name of it
        //[ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }
    }
}
