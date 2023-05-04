using RewardingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RewardingApp
{
    public class ActivitiesDataContext : DbContext
    {
        public ActivitiesDataContext(DbContextOptions<ActivitiesDataContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}
