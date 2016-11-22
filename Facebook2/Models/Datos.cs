using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facebook2.Models
{
    public class Datos
    {
        [Key]
        public int id { get; set; }
        public string datos { get; set; }
    }
}