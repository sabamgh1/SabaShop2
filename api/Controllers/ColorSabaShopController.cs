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
    public class ColorSabaShopController : ControllerBase
    {
        private readonly IColor iColor;
        public ColorSabaShopController(IColor IColor)
        {
            iColor = IColor;
        }

        [HttpPost]
        public IActionResult DeleteColor(int id)
        {
            var result = iColor.DeleteColor(id);
            if (result)
            {
                return Ok(" با موفقیت انجام شد");
            }
            else
            {
                return Ok("موجود نمیباشد!");
            }
        }

        [HttpPost]
        public IActionResult AddColor(MColor Color)
        {
            if (ModelState.IsValid)
            {
                iColor.AddColor(Color);
                return Ok(" با موفقیت انجام شد");

            }

            return BadRequest();

        }


        [HttpPost]
        public IActionResult UpdateColor(MColor Color)
        {
            if (ModelState.IsValid)
            {
                var result = iColor.UpdateColor(Color);
                if (result)
                {
                    return Ok(" با موفقیت انجام شد");
                }
                else
                {
                    return Ok("موجود نمیباشد");
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult ShowColorProduct()
        {
            return Ok(iColor.ShowColorProduct());
        }
    }
}
