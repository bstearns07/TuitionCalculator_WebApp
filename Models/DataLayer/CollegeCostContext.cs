/********************************************************************************************
 * Class representing the context of the application's database for database communications *
 *******************************************************************************************/

using Microsoft.EntityFrameworkCore;

namespace TuitionCalculator_WebApp.Models.DataLayer
{
    public class CollegeCostContext : DbContext
    {
        //constructor that accepts options configured by the middleware of the application
        public CollegeCostContext(DbContextOptions<CollegeCostContext> options) : base(options) { }

        //enable the application to work with collections of the app's model using a public DbSet property
        public DbSet<CollegeCost> CollegeCost { get; set; } = null!;//initialize a default value of null to suppress compiler warnings and improve EF core integration

        //override base class's OnConfiguring method to configure the context of the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //override the base class's OnModelCreating to configure the entity class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
