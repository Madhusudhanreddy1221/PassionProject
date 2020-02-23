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
using PassionProject.Models.ViewModels;

namespace PassionProject.Controllers
{
    public class BikeController : Controller
    {
        private Bikecontext db = new Bikecontext();

        //Get :Bike
        public ActionResult List()
        {

            List<Bikes> Bikes = db.Bikes.SqlQuery("Select * from Bikes").ToList();
            return View(Bikes);

        }

        // Show details for individual Bike
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bikes Bike = db.Bikes.SqlQuery("select * from Bikes where BikeID=@BikeID", new SqlParameter("@BikeID", id)).FirstOrDefault();
            if (Bike == null)
            {
                return HttpNotFound();
            }
            return View(Bike);
        }

        [HttpPost]
        public ActionResult Add(string BikeName, Double BikePrice, String BikeColor, int MakeID, int ModelID,  string BikeNotes)
        {
            //Query to insert values into the table
            string query = "insert into Bikes (BikeName, Price, Color, MakeID, ModelID, Notes) values (@BikeName,@BikePrice,@BikeColor,@MakeID, @ModelId, @BikeNotes)";
            SqlParameter[] sqlparams = new SqlParameter[5];
            // key and value pairs
            sqlparams[0] = new SqlParameter("@BikeName", BikeName);
            sqlparams[1] = new SqlParameter("@BikePrice", BikePrice);
            sqlparams[2] = new SqlParameter("@BikeColor", BikeColor);
            sqlparams[3] = new SqlParameter("@MakeID", MakeID);
            sqlparams[3] = new SqlParameter("@ModelID", ModelID);
            sqlparams[4] = new SqlParameter("@BikeNotes", BikeNotes);

            //executoing the sql query with the values
            db.Database.ExecuteSqlCommand(query, sqlparams);


            // the below code will help you to redirect to lsit view of the page to see the newly addedd value along with other values
            return RedirectToAction("List");
        }
        //Add
        public ActionResult Add()
        {

            List<Make> Make = db.Make.SqlQuery("select * from Makes").ToList();

            
            

            return View(Make);
        }
        //Update
        public ActionResult Update(int id)
        {
            //need information about a particular Bike
            Bikes selectedbike= db.Bikes.SqlQuery("select * from Bikes where BikeID = @id", new SqlParameter("@id", id)).FirstOrDefault();
            string query = "select * from Bikes";
            return View(selectedbike);
        }
        //[HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string BikeName)
        {   //query to update Bikes
            string query = "update Bikes set BikeName=@BikeName, where BikeID=@id";
            //key pair values to hold new values 
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@BikeName", BikeName);
         
            parameters[1] = new SqlParameter("@id", id);
            //Exceuting the sql query with new values
            db.Database.ExecuteSqlCommand(query, parameters);

            //Return to list view of Bikes
            return RedirectToAction("List");
        }
        //delete
        public ActionResult Delete(int id)
        {   //Query to delete particualr Bikes from the table based on the BikeID
            string query = "delete from Bikes where BikeID=@id";
            SqlParameter[] parameter = new SqlParameter[1];
            //storing the id of the Bike to be deleted 
            parameter[0] = new SqlParameter("@id", id);
            //Excecuting the query
            db.Database.ExecuteSqlCommand(query, parameter);
            // returning to lsit view of the Bikes after deleting 
            return RedirectToAction("List");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}