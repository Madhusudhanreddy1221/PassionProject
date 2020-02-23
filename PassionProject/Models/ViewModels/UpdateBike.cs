using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class UpdateBike
    {
        public Bikes Bike { get; set; }
        public List<Make> Make { get; set; }
        public List<Models> Model { get; set; }

    }
}