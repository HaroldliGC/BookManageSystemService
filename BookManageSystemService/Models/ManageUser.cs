using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class ManageUser
    {
        public int Id { get; set; }
        public string Sign { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
    }
}