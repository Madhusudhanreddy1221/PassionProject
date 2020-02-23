using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PassionProject.Data;
using PassionProject.Models;
using System.Diagnostics;

namespace PassionProject.Controllers
{
    public class MakeController :Controller
    {
        private Bikecontext db = new Bikecontext();


        // List Make
        public ActionResult List()
        {

            List<Make> Makes = db.Make.SqlQuery("Select * from Makes").ToList();
            return View(Makes);

        }
        // Show Make Details

        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Make mymake = db.Make.SqlQuery("select * from Makes where MakeID=@MakeID", new SqlParameter("@MakeID", id)).FirstOrDefault();
            if (mymake == null)
            {
                return HttpNotFound();
            }
            return View(mymake);
        }
        //Add Make
        public ActionResult Add()
        {

            List<Make> Make = db.Make.SqlQuery("select * from Makes").ToList();

            return View(Make);
        }
        // [HttpPost] Add
        [HttpPost]
        public ActionResult Add(String Name)
        {   //query to add new Make into the make table
            string query = "insert into Makes (name) values (@Name)";
            SqlParameter parameter = new SqlParameter("@Name",Name);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
        // [HttpPost] Update
        public ActionResult Update(int id)
        {

            string query = "Select * from Makes where  MakeID=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            Make selectedMake = db.Make.SqlQuery(query, parameter).FirstOrDefault();
            return View(selectedMake);
        }
        [HttpPost]
        public ActionResult Update(int id, String Name)
        {   //query to update the particualar Make based on the id
            string query = "update Makes set name=@Name where MakeID=@id";
            //key pair values to store Make details
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@Name", Name);
            parameter[1] = new SqlParameter("@id", id);
            //excecuting the query to update
            db.Database.ExecuteSqlCommand(query, parameter);
            //retunring to list view of the Makes after adding
            return RedirectToAction("List");
        }

        //delete
        public ActionResult Delete(int id)
        {   //Query to delete particualr make from the table based on the make id
            string query = "delete from Makes where MakeID=@id";
            SqlParameter[] parameter = new SqlParameter[1];
            //storing the id of the make to be deleted 
            parameter[0] = new SqlParameter("@id", id);
            //Excecuting the query
            db.Database.ExecuteSqlCommand(query, parameter);
            // returning to lsit view of the make after deleting 
            return RedirectToAction("List");
        }

       
    }
}