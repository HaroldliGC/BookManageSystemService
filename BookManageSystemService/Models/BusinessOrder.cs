using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class BusinessOrder
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReaderUserId { get; set; }
        public ReaderUser ReaderUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BusinessState { get; set; }
        public string OrderState { get; set; }
    }
}