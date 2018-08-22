using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class MyDbContext : DbContext
    {
        // base() calls the parent class's constructor, passing along the "options" parameter
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {            
        }

        // This DbSet contains "Review" objects and is called "Reviews"        
        public DbSet<Review> Reviews { get; set; }
        
        // public DbSet<User> Users { get; set; }
    }
}