using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Make
    {
        [Key]
        public int MakeID { get; set; }
        public string Name { get; set; }

        public ICollection<Bikes> Bikes { get; set; }

    }
}