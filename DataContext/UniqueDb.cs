
using Microsoft.EntityFrameworkCore;
using Unique.Models;
namespace Unique.DataContext
{
    public class UniqueDb : DbContext
    {

        public UniqueDb() { }


        public DbSet<Member> Members { get; set; } // 회원테이블 디비연동
        public DbSet<Category> Categorys { get; set; } // 카테고리테이블 디비연동
        public DbSet<SubCategory> SubCategorys { get; set; } // 하위카테고리 테이블 디비연동
        public DbSet<Product> Products { get; set; } // 상품테이블 디비연동
        public DbSet<ProductImg> ProductImgs { get; set; } // 상품이미지테이블 디비연동
        public DbSet<Cart> Carts { get; set; } // 장바구니테이블 디비연동
        public DbSet<Order> Orders { get; set; } // 주문테이블 디비연동
        public DbSet<Notice> Notices { get; set; } // 공지테이블 디비연동


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=unique;User Id=sa;Password=a123; TrustServerCertificate=True");
        }
    }




}
