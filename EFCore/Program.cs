using EFCore;
using EFCore.Models;

var _context = new ApplicationDbContext();

//var blog = new Blog
//{
//    Name = "Test blog",
//    Url = "test-blog.com"
//};

var blog = new Blog
{
    Name = "Test blog2",
    Url = "test-blog2.com",
    Rating = 4
};

_context.Blogs.Add(blog);
_context.SaveChanges();