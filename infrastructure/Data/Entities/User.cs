using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace infrastructure.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string CodeMeli { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

    }
}