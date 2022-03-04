using System;
using System.ComponentModel.DataAnnotations;

namespace core.Domain
{
    public class MCategory
    {
        public int Id { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "پر کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "پر کنید")]
        public int ParentId { get; set; }
        public string Status { get; set; }
        
    }
}
