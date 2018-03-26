using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookManageSystemService.Models;

namespace BookManageSystemService.Controllers
{
    public class BusinessOrdersController : ApiController
    {
        private BookManageSystemServiceContext db = new BookManageSystemServiceContext();

        // GET: api/BusinessOrders
        public IQueryable<BusinessOrder> GetBusinessOrders()
        {
            return db.BusinessOrders.Include(b => b.Book).Include(b => b.ReaderUser);
        }

        // GET: api/BusinessOrders/5
        public IQueryable<BusinessOrder> GetBusinessOrder(int id)
        {
            return db.BusinessOrders.Where(b => b.Id == id).Include(b => b.Book).Include(b => b.ReaderUser);
        }
        // GET:
        [ResponseType(typeof(BusinessOrder))]
        public IQueryable<BusinessOrder> GetBusinessOrderBySearch([FromUri] string UserName, [FromUri] string BookName)
        {
            if (UserName == null)
            {
                UserName = "";
            }
            if (BookName == null)
            {
                BookName = "";
            }
            var temp = db.BusinessOrders.Where(order => order.ReaderUser.Name.Contains(UserName)).Include(b => b.Book).Include(b => b.ReaderUser);
            var rec = temp.Where(order => order.Book.Name.Contains(BookName)).Include(b => b.Book).Include(b => b.ReaderUser);

            return rec;
        }
        //GET
        [ResponseType(typeof(BusinessOrder))]
        public IQueryable<BusinessOrder> GetGetBusinessOrderByAccount([FromUri] string Account)
        {
            var rec = db.BusinessOrders.Where(order => order.ReaderUser.AccountNumber == Account).Include(b => b.Book);
            return rec;
        }

        // PUT: api/BusinessOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBusinessOrder(int id, BusinessOrder businessOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(businessOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BusinessOrders
        [ResponseType(typeof(BusinessOrder))]
        public async Task<IHttpActionResult> PostBusinessOrder(BusinessOrder businessOrder)
        {
            Book book = await db.Books.FindAsync(businessOrder.BookId);
            book.ResidueNumber = book.ResidueNumber - 1;
            book.BorrowNumber = book.BorrowNumber + 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //更新书籍信息
            db.Entry(book).State = EntityState.Modified;
            //插入订单数据
            db.BusinessOrders.Add(businessOrder);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = businessOrder.Id }, businessOrder);
        }

        // DELETE: api/BusinessOrders/5
        [ResponseType(typeof(BusinessOrder))]
        public async Task<IHttpActionResult> DeleteBusinessOrder(int id)
        {
            BusinessOrder businessOrder = await db.BusinessOrders.FindAsync(id);
            if (businessOrder == null)
            {
                return NotFound();
            }

            db.BusinessOrders.Remove(businessOrder);
            await db.SaveChangesAsync();

            return Ok(businessOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessOrderExists(int id)
        {
            return db.BusinessOrders.Count(e => e.Id == id) > 0;
        }
    }
}