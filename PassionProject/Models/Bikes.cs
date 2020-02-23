using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Bikes
    {
        [Key]
        public int BikeID { get; set; }
        public int MakeID { get; set; }
        [ForeignKey("MakeID")]
        public virtual Make Make  { get; set; }
        public int ModelID { get; set; }
        [ForeignKey("ModelID")]

        public virtual Models Models { get; set; }
        public string BikeName { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
    }
}