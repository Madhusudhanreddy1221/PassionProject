using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int BikeID { get; set; }
        [ForeignKey("BikeID")]
        public virtual Bikes Bikes { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }
        public DateTime Orderdate { get; set; }
    }
}