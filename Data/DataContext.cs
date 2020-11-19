using Learningcsharp.Dtos.Characters;
using Learningcsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace Learningcsharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<Character> Characters {get; set;}
        public DbSet<User> Users {get; set;}

        public DbSet<Weapon> weapons {get; set;}
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");
        }
    }
}