using System;

namespace core.Domain
{
    public class MBaner
    {
        public int Id { get; set; }
        public string NameBaner { get; set; }
        public string ImageBaner { get; set; }
        public bool Status { get; set; }
        public int IdProduct { get; set; }
    }
}