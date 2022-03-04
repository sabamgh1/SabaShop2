using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace core.Domain
{
    public class MUser
    {
       public int Id { get; set; }

        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }


        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }



        [Display(Name = "تاریخ عضویت")]
        public DateTime Date { get; set; }

        [Display(Name = "کد ملی")]
        public string CodeMeli { get; set; }

        public string Role { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

    }
}