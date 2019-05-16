using Microsoft.EntityFrameworkCore;

namespace WildlifePark.Models
{
    public class WildlifeParkContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"server=localhost;user id=root;password=root;port=3306;database=wildlife_park;");

        public WildlifeParkContext(DbContextOptions options) : base(options)
        {

        }
        public WildlifeParkContext()
        {

        }

    }
}