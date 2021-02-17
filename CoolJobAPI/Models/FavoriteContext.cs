using Microsoft.EntityFrameworkCore;

namespace CoolJobAPI.Models
{
    public class FavoriteContext : DbContext
    {
        public FavoriteContext(DbContextOptions<FavoriteContext> options)
            : base(options)
        {
        }
        public DbSet<Job> Favorites { get; set; }
    }
}
