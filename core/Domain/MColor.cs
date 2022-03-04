using System;
using System.ComponentModel.DataAnnotations;
namespace core.Domain
{
    public class MColor
    {
        public int Id { get; set; }
        public string color { get; set; }
        [Required(ErrorMessage = "پر کنید")]
        public int IdProduct { get; set; }
    }
}