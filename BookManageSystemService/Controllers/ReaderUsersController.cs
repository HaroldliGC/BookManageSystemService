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
    public class ReaderUsersController : ApiController
    {
        private BookManageSystemServiceContext db = new BookManageSystemServiceContext();

        // GET: api/ReaderUsers
        public IQueryable<ReaderUserDTO> GetReaderUsers()
        {
            var readerUsers = from b in db.ReaderUsers
                              select new ReaderUserDTO()
                              {
                                  Id = b.Id,
                                  Name = b.Name,
                                  AccountNumber = b.AccountNumber,
                                  State = b.State,
                                  Gender = b.Gender,
                                  Email = b.Email,
                                  Age = b.Age,
                                  Phone = b.Phone
                              };
            return readerUsers;
        }

        // GET: api/ReaderUsers/5
        [ResponseType(typeof(ReaderUser))]
        public async Task<IHttpActionResult> GetReaderUser(int id)
        {
            ReaderUser readerUser = await db.ReaderUsers.FindAsync(id);
            if (readerUser == null)
            {
                return NotFound();
            }

            return Ok(readerUser);
        }
        //GET:api/ReaderUsers/
        public IQueryable<ReaderUserDTO> GetReaderUserBySearch([FromUri] string Name, [FromUri] string AccountNumber)
        {
            if (Name == null)
            {
                Name = "";
            }
            var temp = db.ReaderUsers.Where(user => user.Name.Contains(Name));
            if (AccountNumber != null)
            {
                temp = temp.Where(user => user.AccountNumber.Contains(AccountNumber));
            }
            var rec = from user in temp
                      select new ReaderUserDTO()
                      {
                          Id = user.Id,
                          Name = user.Name,
                          AccountNumber = user.AccountNumber,
                          State = user.State,
                          Gender = user.Gender,
                          Email = user.Email,
                          Age = user.Age,
                          Phone = user.Phone
                      };
            return rec;
        }

        // PUT: api/ReaderUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReaderUser(int id, ReaderUserDTO readerUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != readerUserDTO.Id)
            {
                return BadRequest();
            }
            ReaderUser readerUser = await db.ReaderUsers.FindAsync(id);
            readerUser.State = readerUserDTO.State;
            db.Entry(readerUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderUserExists(id))
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

        // POST: api/ReaderUsers
        [ResponseType(typeof(ReaderUser))]
        public async Task<IHttpActionResult> PostReaderUser(ReaderUser readerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReaderUsers.Add(readerUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = readerUser.Id }, readerUser);
        }

        // DELETE: api/ReaderUsers/5
        [ResponseType(typeof(ReaderUser))]
        public async Task<IHttpActionResult> DeleteReaderUser(int id)
        {
            ReaderUser readerUser = await db.ReaderUsers.FindAsync(id);
            if (readerUser == null)
            {
                return NotFound();
            }

            db.ReaderUsers.Remove(readerUser);
            await db.SaveChangesAsync();

            return Ok(readerUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReaderUserExists(int id)
        {
            return db.ReaderUsers.Count(e => e.Id == id) > 0;
        }
    }
}
