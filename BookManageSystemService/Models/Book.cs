using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Press { get; set; }
        public double Price { get; set; }
        public string Info { get; set; }
        public int Number { get; set; }

        public int BorrowNumber { get; set; }
        public int ResidueNumber { get; set; }
        // Foreign Key
        public string Author { get; set; }
    }
}