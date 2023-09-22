using Dotnet_8_First.Data;
using Dotnet_8_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_8_First.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _context;

        public CouponRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Coupon> AddCouponAsync(Coupon coupon)
        {
            var data = await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Coupon> DeleteCouponAsync(Coupon coupon)
        {
            var data = _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Coupon> GetCouponAsync(int id)
        {
            var getData = await _context.Coupons.FindAsync(id);
            return getData;
        }

        public async Task<IEnumerable<Coupon>> GetCouponsAsync()
        {
            var data = await _context.Coupons.ToListAsync();
            return data;
        }

        public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
        {
            var data = _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
    }
}
