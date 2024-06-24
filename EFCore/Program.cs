using EFCore;
using EFCore.Models;

var _context = new ApplicationDbContext();

//var author = new Author
//{
//    FirstName = "Mohamed",
//    LastName = "Gomaa"
//};

//To get row with Id = 1
var row =_context.Authors.Find(1);
row.LastName = "Salem";

_context.SaveChanges();