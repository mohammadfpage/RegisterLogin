using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using UniProject.Models.Entity.Users;

namespace UniProject.Migrations.Context
{
    
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<User> Users { get; set; }
        
    }
}
