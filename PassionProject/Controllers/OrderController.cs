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
    public class OrderController :Controller
    {
        private Bikecontext db = new Bikecontext();

        // GET: list of orders
        public ActionResult List()
        {

            List<Order> order = db.Order.SqlQuery("Select * from Orders").ToList();
            return View(order);

        }

        // Show details for individual order
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order Order = db.Order.SqlQuery("select * from Orders where OrderID=@OrderID", new SqlParameter("@OrderID", id)).FirstOrDefault();
            if (Order == null)
            {
                return HttpNotFound();
            }
            return View(Order);
        }

    }
}