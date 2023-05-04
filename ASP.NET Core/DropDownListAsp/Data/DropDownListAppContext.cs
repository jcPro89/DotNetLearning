using DropDownListAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace DropDownListAsp.Data
{
    public class DropDownListAppContext:DbContext
    {
        public DropDownListAppContext(DbContextOptions<DropDownListAppContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }   
        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
