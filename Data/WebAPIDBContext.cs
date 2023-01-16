using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class WebAPIDBContext: DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options):base(options){}

        public DbSet<Products> Products { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}   
