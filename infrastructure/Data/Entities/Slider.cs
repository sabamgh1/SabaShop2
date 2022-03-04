using System;

namespace infrastructure.Data.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string NameSlider { get; set; }
        public string ImageSlider { get; set; }
        public bool Status { get; set; }
        public int IdProduct { get; set; }
    }
}