using System;

namespace infrastructure.Data.Entities
{
    public class Baner
    {
        public int Id { get; set; }
        public string NameBaner { get; set; }
        public string ImageBaner { get; set; }
        public bool Status { get; set; }
        public int IdProduct { get; set; }
    }
}