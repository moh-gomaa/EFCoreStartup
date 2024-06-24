using EFCore;
using EFCore.Models;

var _context = new ApplicationDbContext();

var category = new Category
{
    Name = "Test3"
};

_context.Categories.Add(category);

_context.SaveChanges();