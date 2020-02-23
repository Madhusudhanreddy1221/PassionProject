using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PassionProject.Data
{
    public class Bikecontext : DbContext
    {


        public Bikecontext() : base("name=BikeContext")
        {
        }

        public System.Data.Entity.DbSet<PassionProject.Models.Bikes> Bikes { get; set; }

        public System.Data.Entity.DbSet<PassionProject.Models.Customers> Customers { get; set; }
        public System.Data.Entity.DbSet<PassionProject.Models.Make> Make { get; set; }
        public System.Data.Entity.DbSet<PassionProject.Models.Models> Models { get; set; }
        public System.Data.Entity.DbSet<PassionProject.Models.Order> Order { get; set; }
    }
}