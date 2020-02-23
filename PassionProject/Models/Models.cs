using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Models
    {
        [Key]
        public int ModelID { get; set; }
        public string Name { get; set; }

        public string Year { get; set; }

        public string EngineType { get; set; }

        public string Power { get; set; }

        public string TopSpeed { get; set; }


    }
}