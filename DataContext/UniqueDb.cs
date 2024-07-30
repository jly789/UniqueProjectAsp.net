
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Unique.Models.member;

namespace Unique.DataContext
{
    public class UniqueDb : DbContext
    {

        public UniqueDb() { }




        public DbSet<Member> Members { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=unique;User Id=sa;Password=a123; TrustServerCertificate=True");
        }
    }




}
