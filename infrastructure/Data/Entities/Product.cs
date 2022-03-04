using System;
using System.Collections.Generic;

namespace infrastructure.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public int Count { get; set; }
        public string discription { get; set; }
        public string MainImage { get; set; }
        public int IdCategory { get; set; }
        public string MoreImage { get; set; }
        public bool Status { get; set; }
        public int IdColor { get; set; }
        public int IdSize { get; set; }
        public int discount { get; set; }
        public string Type { get; set; }
        
        
    }
}