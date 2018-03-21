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
    public class ManageUsersController : ApiController
    {
        private BookManageSystemServiceContext db = new BookManageSystemServiceContext();

        // GET: api/ManageUsers
        public IQueryable<ManageUser> GetManageUsers()
        {
            return db.ManageUsers;
        }

        // GET: api/ManageUsers/5
        [ResponseType(typeof(ManageUser))]
        public async Task<IHttpActionResult> GetManageUser(int id)
        {
            ManageUser manageUser = await db.ManageUsers.FindAsync(id);
            if (manageUser == null)
            {
                return NotFound();
            }

            return Ok(manageUser);
        }
        //GET
        public string GetManageUserLogin([FromUri] string userAccount, [FromUri] string userPassword, [FromUri] string userSign)
        {
            string signal = "success";
            var temp = db.ManageUsers.Where(user => user.AccountNumber == userAccount && user.Password == userPassword && user.Sign == userSign);
            if (!temp.Any())
            {
                signal = "failed";
            }
            return signal;
        }
        // PUT: api/ManageUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutManageUser(int id, ManageUser manageUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manageUser.Id)
            {
                return BadRequest();
            }

            db.Entry(manageUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageUserExists(id))
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

        // POST: api/ManageUsers
        [ResponseType(typeof(ManageUser))]
        public async Task<IHttpActionResult> PostManageUser(ManageUser manageUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ManageUsers.Add(manageUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = manageUser.Id }, manageUser);
        }

        // DELETE: api/ManageUsers/5
        [ResponseType(typeof(ManageUser))]
        public async Task<IHttpActionResult> DeleteManageUser(int id)
        {
            ManageUser manageUser = await db.ManageUsers.FindAsync(id);
            if (manageUser == null)
            {
                return NotFound();
            }

            db.ManageUsers.Remove(manageUser);
            await db.SaveChangesAsync();

            return Ok(manageUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManageUserExists(int id)
        {
            return db.ManageUsers.Count(e => e.Id == id) > 0;
        }
    }
}