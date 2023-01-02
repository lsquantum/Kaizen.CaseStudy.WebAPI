using Kaizen.CaseStudy.WebAPI.Coupon;
using Microsoft.AspNetCore.Mvc;

namespace Kaizen.CaseStudy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ILogger<CouponController> _logger;

        public CouponController(ILogger<CouponController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetCouponCode")]
        public string GetCouponCode()
        {
            return CouponCodeGenerator.GenerateCouponCode();
        }

        [HttpPost(Name = "ValidateCouponCode")]
        public bool ValidateCouponCode(string couponCode)
        {
            if (!CouponCodeGenerator.IsFormatValidCouponCode(couponCode))
                return false;

            return CouponCodeGenerator.IsValidCouponCode(couponCode);
        }
    }
}