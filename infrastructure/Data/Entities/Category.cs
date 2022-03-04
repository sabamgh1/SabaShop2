using System;

namespace infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Status { get; set; }
        
    }
}
