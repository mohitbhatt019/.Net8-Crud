using AutoMapper;
using Dotnet_8_First.Data;
using Dotnet_8_First.Models;
using Dotnet_8_First.Models.DTO;
using Dotnet_8_First.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_8_First.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ResponseDTO _response;
        private readonly IMapper _mapper;
        private readonly ICouponRepository _context;

        public CouponController(ICouponRepository context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDTO();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var objList = await _context.GetCouponsAsync();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO> Get(int id)
        {
            try
            {
                var obj = await _context.GetCouponAsync(id);
                _response.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] CouponDTO couponDto)
        {
            try
            {
                var data = _mapper.Map<Coupon>(couponDto);
                var createCoupon = await _context.AddCouponAsync(data);
                _response.Result = _mapper.Map<CouponDTO>(data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDTO> Put([FromBody] CouponDTO couponDto)
        {
            try
            {
                var data = _mapper.Map<Coupon>(couponDto);
                var createCoupon = _context.UpdateCouponAsync(data);
                _response.Result = _mapper.Map<CouponDTO>(data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var deleteCoupon = await _context.GetCouponAsync(id);
                await _context.DeleteCouponAsync(deleteCoupon);
                _response.Result = _mapper.Map<CouponDTO>(deleteCoupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}