namespace BookManageSystemService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using BookManageSystemService.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookManageSystemService.Models.BookManageSystemServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookManageSystemService.Models.BookManageSystemServiceContext context)
        {
            DateTime startDate1 = new DateTime(2018, 1, 1);
            DateTime endDate1 = new DateTime(2018, 2, 1);
            DateTime returnDate1 = new DateTime(2018, 1, 29);
            DateTime[] startDates = new DateTime[] {new DateTime(2018, 1, 1),new DateTime(2017, 11, 21), new DateTime(2018, 2, 1), new DateTime(2018, 1, 1), new DateTime(2018, 1, 15)};
            DateTime[] endDates = new DateTime[] { new DateTime(2018, 2, 1),new DateTime(2018, 1, 21), new DateTime(2018, 5, 1), new DateTime(2018, 2, 1), new DateTime(2018, 2, 15) };
            DateTime[] returnDates = new DateTime[] { new DateTime(2018, 1, 29), new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), new DateTime(2018, 2, 28), new DateTime(2018, 2, 1)};
            context.ReaderUsers.AddOrUpdate(x => x.Id,
                new ReaderUser() { Id = 1, Name = "LiMai", Gender = "man", State = "normal", Age = 21, AccountNumber = "1029147576@qq.com", Password = "123456", Phone = "15002993081", Email = "1029147576@qq.com" },
                new ReaderUser() { Id = 2, Name = "SunHang", Gender = "man", State = "normal", Age = 19, AccountNumber = "7827576@qq.com", Password = "123456", Phone = "13636735987", Email = "7827576@qq.com" },
                new ReaderUser() { Id = 3, Name = "LiJiao", Gender = "woman", State = "normal", Age = 22, AccountNumber = "532892348@qq.com", Password = "123456", Phone = "13772591819", Email = "532892348@qq.com" }
                );
            /*
            context.BusinessOrders.AddOrUpdate(x => x.Id,
                new BusinessOrder() { Id = 1, BookId = 1, ReaderUserId = 1, StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 2, 1), ReturnDate = new DateTime(2018, 1, 29), BusinessState = "normal", OrderState = "finish" },
                new BusinessOrder() { Id = 2, BookId = 2, ReaderUserId = 2, StartDate = new DateTime(2017, 11, 21), EndDate = new DateTime(2018, 1, 21), BusinessState = "overTime", OrderState = "unfinish" },
                new BusinessOrder() { Id = 3, BookId = 1, ReaderUserId = 3, StartDate = new DateTime(2018, 2, 1), EndDate = new DateTime(2018, 5, 1), BusinessState = "normal", OrderState = "unfinish" },
                new BusinessOrder() { Id = 4, BookId = 3, ReaderUserId = 2, StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 2, 1), ReturnDate = new DateTime(2018, 2, 28), BusinessState = "overTime", OrderState = "finish" },
                new BusinessOrder() { Id = 5, BookId = 1, ReaderUserId = 2, StartDate = new DateTime(2018, 1, 15), EndDate = new DateTime(2018, 2, 15), ReturnDate = new DateTime(2018, 2, 1), BusinessState = "normal", OrderState = "finish" }
                );
                */
            context.BusinessOrders.AddOrUpdate(x => x.Id,
               new BusinessOrder() { Id = 1, BookId = 1, ReaderUserId = 1, StartDate = startDates[0], EndDate = endDates[0], ReturnDate = returnDates[0], BusinessState = "normal", OrderState = "finished" },
               new BusinessOrder() { Id = 2, BookId = 2, ReaderUserId = 2, StartDate = startDates[1], EndDate = endDates[1], ReturnDate = returnDates[1], BusinessState = "overTime", OrderState = "unfinished" },
               new BusinessOrder() { Id = 3, BookId = 1, ReaderUserId = 3, StartDate = startDates[2], EndDate = endDates[2], ReturnDate = returnDates[2], BusinessState = "normal", OrderState = "unfinished" },
               new BusinessOrder() { Id = 4, BookId = 3, ReaderUserId = 2, StartDate = startDates[3], EndDate = endDates[3], ReturnDate = returnDates[3], BusinessState = "overTime", OrderState = "finished" },
               new BusinessOrder() { Id = 5, BookId = 1, ReaderUserId = 2, StartDate = startDates[4], EndDate = endDates[4], ReturnDate = returnDates[4], BusinessState = "normal", OrderState = "finished" }
               );
            context.ManageUsers.AddOrUpdate(x => x.Id,
                new ManageUser() { Id = 1, AccountNumber = "admin", Password = "xA123456", Sign = "1"},
                new ManageUser() { Id = 2, AccountNumber = "admin", Password = "xA123456", Sign = "2" },
                new ManageUser() { Id = 3, AccountNumber = "admin", Password = "xA123456", Sign = "3" }
                );
           context.Books.AddOrUpdate(x => x.Id,
        new Book()
        {
            Id = 1,
            Isbn = "978-7-115-39060-8",
            Name = "JavaScripet函数式编程",
            Type = "计算机",
            Press = "人民邮电出版社",
            Price = 49.00,
            Info = "本书内容全面，示例丰富，适合想要了解函数式编程的JavaScri程序员和学习JavaScript的函数式程序员阅读",
            Number = 120,
            Author = "Michael Fogus",
            BorrowNumber = 60,
            ResidueNumber = 60
        },
        new Book()
        {
            Id = 2,
            Isbn = "978-7-115-31008-8",
            Name = "编写可维护的JavaScripet",
            Type = "计算机",
            Press = "人民邮电出版社",
            Price = 55.00,
            Info = "本书适合前段开发工程师、JavaScript程序员和学习JavaScript编程的读者阅读，也适合项目负责人阅读",
            Number = 110,
            Author = "Nicholas C. Zakas",
            BorrowNumber = 45,
            ResidueNumber = 65
        },
        new Book()
        {
            Id = 3,
            Isbn = "978-7-508-35594-8",
            Name = "CSS权威指南",
            Type = "计算机",
            Press = "中国电力出版社",
            Price = 58.00,
            Info = "本书详细介绍了各个CSS属性，及属性间的相互作用",
            Number = 220,
            Author = "Nicholas C. Zakas",
            BorrowNumber = 100,
            ResidueNumber = 120
        },
        new Book()
        {
            Id = 4,
            Isbn = "978-7-508-35594-9",
            Name = "C#权威指南",
            Type = "计算机",
            Press = "中国电力出版社",
            Price = 28.80,
            Info = "本书详细介绍了C#",
            Number = 20,
            Author = "Eric A Meyer",
            BorrowNumber = 11,
            ResidueNumber = 9
        },
        new Book()
        {
            Id = 5,
            Isbn = "978-7-121-27657-6",
            Name = "ES6标准入门",
            Type = "计算机/Web开发/JavaScript",
            Press = "电子工业出版社",
            Price = 69,
            Info = "本书介绍了ES6的标准",
            Number = 165,
            Author = "阮一峰",
            BorrowNumber = 30,
            ResidueNumber = 135
        }
        );
        }
    }
}
