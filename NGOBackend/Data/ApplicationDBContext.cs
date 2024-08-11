using Microsoft.EntityFrameworkCore;
using NGOBackend.Models;

namespace NGOBackend.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        // models go here
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
