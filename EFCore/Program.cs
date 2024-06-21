using EFCore;

var _context = new ApplicationDbContext();

//var employee = new Employee
//{
//    Name = "Employee 1"
//};

var employee = new Employee();

_context.Employees.Add(employee);
_context.SaveChanges();