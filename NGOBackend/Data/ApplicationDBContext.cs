using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NGOBackend.Models;
using System.Reflection.Emit;

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
        public DbSet<UserProject> UserProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserProject>(x => x.HasKey(p => new { p.UserId, p.ProjectId }));

            builder.Entity<UserProject>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId);

          
        }
    }
}
