using InterceptorTest.Entities;
using InterceptorTest.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace InterceptorTest.DBContext
{
    public class MyDbContext : DbContext
    { 
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {        
            optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=CustomsDev;Persist Security Info=False;User ID=sa;Password=*******;TrustServerCertificate=True");
            optionsBuilder.AddInterceptors(new AddAuditDataInterceptor());
        
        }
    }
}
