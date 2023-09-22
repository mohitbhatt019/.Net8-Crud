using Dotnet_8_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_8_First.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
