
using Microsoft.EntityFrameworkCore;
using Unique.Models;
namespace Unique.DataContext
{
    public class UniqueDb : DbContext
    {

        public UniqueDb() { }




        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImg> ProductImgs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=unique;User Id=sa;Password=a123; TrustServerCertificate=True");
        }
    }




}
