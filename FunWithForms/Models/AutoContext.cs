using Microsoft.EntityFrameworkCore;

namespace FunWithForms.Models
{
    public class AutoContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CarTesting;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
