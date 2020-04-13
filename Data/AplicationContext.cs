using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<StaffPerson> StaffPeople { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<Weather> Weathers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext()
        : base()
        {
        }
    }
}
