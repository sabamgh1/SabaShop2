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
    public class UserSabaShopController : ControllerBase
    {
        private readonly IUser iUser;
        public UserSabaShopController(IUser IUser)
        {
            iUser = IUser;
        }

        [HttpPost]
        public IActionResult LoginUser(string mobile, string password)
        {
            var result=iUser.LoginUser(mobile,password);
            if (result!=null)
            {
                 return Ok(result);
            }
            else
            {
               return Ok("کاربری وجود ندارد!"); 
            }
            
        }

        [HttpPost]
        public IActionResult CheckExistUser(string Mobile)
        {
            var result=iUser.CheckExistUser(Mobile);
            if (result)
            {
                return Ok("وجود دارد");
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost]
        public IActionResult AddUser(MUser User)
        {
            if (ModelState.IsValid)
            {
                iUser.AddUser(User);
                return Ok(" با موفقیت انجام شد");

            }

            return BadRequest();

        }


        [HttpPost]
        public IActionResult GetUserRole(string Mobile)
        {
            var result=iUser.GetUserRole(Mobile);
            return Ok(result);

        }

        [HttpPost]
        public IActionResult CheckActivateUser(string Mobile)
        {
            var result=iUser.CheckActivateUser(Mobile);
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult DeleteUser(int Id)
        {
            var result = iUser.DeleteUser( Id);
            if (result)
            {
                return Ok(" با موفقیت انجام شد");
            }
            else
            {
                return Ok("  وجود ندارد!");
            }
        }

        [HttpGet]
        public IActionResult ShowDetailUser(string Mobile)
        {
            var result = iUser.ShowDetailUser( Mobile);
            return Ok(result);
        }
    
        [HttpPost]
        public IActionResult UpdatePassword(string Mobile, string Password,string NewPassword)
        {
            
                var result = iUser.UpdatePassword(Mobile, Password,NewPassword);
                if (result=="1")
                {
                    return Ok(" با موفقیت انجام شد");
                }
                else
                {
                    return Ok("در وارد کردن ورودی دقت فرمایید!");
                }
            
        }


        [HttpPost]
        public IActionResult UpdateDetailUser(string Mobile,string FullName,string CodeMeli,bool IsActive)
        {
            if (ModelState.IsValid)
            {
                var result = iUser.UpdateDetailUser(Mobile,FullName,CodeMeli,IsActive);
                if (result)
                {
                    return Ok(" با موفقیت انجام شد");
                }
                else
                {
                    return Ok(" شماره موبایل وجود ندارد");
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateUserRole(string Mobile,string Role)
        {
            if (ModelState.IsValid)
            {
                var result = iUser.UpdateUserRole(Mobile,Role);
                if (result)
                {
                    return Ok(" با موفقیت انجام شد");
                }
                else
                {
                    return Ok(" شماره موبایل وجود ندارد");
                }
            }
            return BadRequest();
        }
 
    
    }
}
