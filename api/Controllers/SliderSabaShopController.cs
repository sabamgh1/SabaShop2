using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Domain;
using core.Repository;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SliderSabaShopController : ControllerBase
    {
        private readonly ISlider iSlider;
        public SliderSabaShopController(ISlider ISlider)
        {
            iSlider = ISlider;
        }


        [HttpPost]
        public IActionResult UpdateSlider(MSlider Slider)
        {
            if (ModelState.IsValid)
            {
                var result = iSlider.UpdateSlider(Slider);
                if (result)
                {
                    return Ok(" با موفقیت انجام شد");
                }
                else
                {
                    return Ok("  وجود ندارد");
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddSlider(MSlider Slider)
        {
            if (ModelState.IsValid)
            {
                iSlider.AddSlider(Slider);
                return Ok("عملیات با موفقیت انجام شد");

            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult ShowActiveImageSlider()
        {
            return Ok(iSlider.ShowActiveImageSlider());
        }

        [HttpPost]
        public IActionResult DeleteSlider(int id)
        {
            var result = iSlider.DeleteSlider(id);
            if (result)
            {
                return Ok("عملیات با موفقیت انجام شد");
            }
            else
            {
                return Ok("این آیدی وجود ندارد!");
            }
        }

        [HttpPost]
        public IActionResult ShowProductSlider(int IdSlider)
        {
            return Ok(iSlider.ShowProductSlider(IdSlider));
        }
    }
}
