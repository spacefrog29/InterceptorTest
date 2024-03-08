// See https://aka.ms/new-console-template for more information
using InterceptorTest.DBContext;

Console.WriteLine("Hello, World!");

MyDbContext dbx = new MyDbContext();

// Add a user
//dbx.Users.AddAsync(new InterceptorTest.Entities.Users()
//{
//    FirstName = "Dean",
//    LastName = "Test"
//});

// Update a user
var user = dbx.Users.FirstOrDefault(x=>x.Id == 1);
if (user != null)
{ 
user.LastName = "Test";
}


dbx.SaveChanges();
Console.WriteLine("Done !!!");
Console.ReadLine();

