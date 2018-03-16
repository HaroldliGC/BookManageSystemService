using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class ReaderUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}