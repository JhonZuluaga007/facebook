using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facebook2.Models
{
    public class usuario
    {
        [Key]
        public string id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}