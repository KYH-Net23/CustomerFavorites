using Microsoft.EntityFrameworkCore;
using WebApiFavorites.Models;

namespace WebApiFavorites.Data
{
    public class FavoriteDbContext : DbContext
    {
        public FavoriteDbContext(DbContextOptions<FavoriteDbContext> options) : base(options) { }
        
       public DbSet<Favorite> Favorites {  get; set; }     

    }
}
