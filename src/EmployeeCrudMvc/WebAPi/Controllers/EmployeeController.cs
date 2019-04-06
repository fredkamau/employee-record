using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPi.Models;

namespace WebAPi.Controllers
{
    public class EmployeeController : ApiController
    {
        private MyDB db = new MyDB();

        // GET: api/Employee
        public IQueryable<employee_tbl> Getemployee_tbl()
        {
            return db.employee_tbl;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(employee_tbl))]
        public IHttpActionResult Getemployee_tbl(int id)
        {
            employee_tbl employee_tbl = db.employee_tbl.Find(id);
            if (employee_tbl == null)
            {
                return NotFound();
            }

            return Ok(employee_tbl);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee_tbl(int id, employee_tbl employee_tbl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != employee_tbl.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employee_tblExists(id))
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

        // POST: api/Employee
        [ResponseType(typeof(employee_tbl))]
        public IHttpActionResult Postemployee_tbl(employee_tbl employee_tbl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.employee_tbl.Add(employee_tbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee_tbl.EmployeeId }, employee_tbl);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(employee_tbl))]
        public IHttpActionResult Deleteemployee_tbl(int id)
        {
            employee_tbl employee_tbl = db.employee_tbl.Find(id);
            if (employee_tbl == null)
            {
                return NotFound();
            }

            db.employee_tbl.Remove(employee_tbl);
            db.SaveChanges();

            return Ok(employee_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employee_tblExists(int id)
        {
            return db.employee_tbl.Count(e => e.EmployeeId == id) > 0;
        }
    }
}