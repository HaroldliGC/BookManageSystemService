using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class BookSearchInf
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Press { get; set; }
        public string Author { get; set; }
    }
}