using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookManageSystemService.Models
{
    public class BookManageSystemServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BookManageSystemServiceContext() : base("name=BookManageSystemServiceContext")
        {
        }

        public System.Data.Entity.DbSet<BookManageSystemService.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<BookManageSystemService.Models.ReaderUser> ReaderUsers { get; set; }

        public System.Data.Entity.DbSet<BookManageSystemService.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<BookManageSystemService.Models.BusinessOrder> BusinessOrders { get; set; }

        public System.Data.Entity.DbSet<BookManageSystemService.Models.ManageUser> ManageUsers { get; set; }
    }
}
