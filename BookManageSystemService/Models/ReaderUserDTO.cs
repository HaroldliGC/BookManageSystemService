using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class ReaderUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}