using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("User ID=postgres;Password=Aa251006@10;Server=localhost;Port=5432;Database=webstore;Integrated Security=true;Pooling=true;");
        // }
    }
}