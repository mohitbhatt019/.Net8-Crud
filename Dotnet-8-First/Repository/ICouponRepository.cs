using Dotnet_8_First.Models;

namespace Dotnet_8_First.Repository
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetCouponsAsync();
        Task<Coupon> GetCouponAsync(int id);
        Task<Coupon> AddCouponAsync(Coupon coupon);
        Task<Coupon> UpdateCouponAsync(Coupon coupon);
        Task<Coupon> DeleteCouponAsync(Coupon coupon);
    }
}
