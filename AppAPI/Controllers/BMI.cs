using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppData;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMI : ControllerBase
    {
        [HttpGet("get-BMI")]
        public ActionResult GetBMI(double weight , double height)
        {
            if(weight <= 0 || height <=0)
            {
                return BadRequest("Cân nặng và chiều cao phải > 0 ");
            }
            var BMI = weight / (height * height);
            return Content($"Chỉ số BMI của bạn là : {BMI}");

        }
    }
 
   
}
