using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Customers
    {   [Key]
        public int CustomerID { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerHomePhone { get; set; }
    }
}