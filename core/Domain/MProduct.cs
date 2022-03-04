using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace core.Domain
{
    public class MProduct
    {
        public int Id { get; set; }

        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "پر کنید")]
        public string Name { get; set; }
        public double price { get; set; }
        public int Count { get; set; }
        public string discription { get; set; }
        public string MainImage { get; set; }

        [Required(ErrorMessage = "پر کنید")]
        public int IdCategory { get; set; }
        public bool Status { get; set; }
        public int IdColor { get; set; }
        public int IdSize { get; set; }
        public string MoreImage { get; set; }
        public int discount { get; set; }
        public string Type { get; set; }
        
        
    }
}