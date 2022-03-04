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
    public class ProductSabaShopController : ControllerBase
    {
        private readonly IProduct iProduct;
        public ProductSabaShopController(IProduct IProduct)
        {
            iProduct = IProduct;
        }

        [HttpGet]
        public IActionResult ShowActiveStatusProduct()
        {
            return Ok(iProduct.ShowActiveStatusProduct());
        }

        [HttpGet]
        public IActionResult ShowProductCategory(int IdCategory)
        {
            return Ok(iProduct.ShowProductCategory(IdCategory));
        }

        [HttpGet]
        public IActionResult ShowProductType(string Type)
        {
            return Ok(iProduct.ShowProductType(Type));
        }
        [HttpPost]
        public IActionResult AddProduct(MProduct Product)
        {
            if (ModelState.IsValid)
            {
                iProduct.AddProduct(Product);
                return Ok(" با موفقیت انجام شد");

            }

            return BadRequest();

        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var result = iProduct.DeleteProduct(id);
            if (result)
            {
                return Ok(" با موفقیت انجام شد");
            }
            else
            {
                return Ok("  وجود ندارد!");
            }
        }
        [HttpPost]
        public IActionResult UpdateProduct(MProduct Product)
        {
            if (ModelState.IsValid)
            {
                var result = iProduct.UpdateProduct(Product);
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

        [HttpGet]
        public IActionResult DetailsProduct(int IdProduct)
        {
            return Ok(iProduct.DetailsProduct(IdProduct));
        }
    
    }
}
