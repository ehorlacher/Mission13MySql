using Microsoft.EntityFrameworkCore;

namespace Mission13MySql.Models
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
    }
}
