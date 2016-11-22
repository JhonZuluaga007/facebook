using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facebook2.Models
{
    public class comments
    {
        [Key]
        public int Comments_id { get; set; }
        public int Publication_id { get; set; }
        public string user { get; set; }
        public string userimg { get; set; }
        public string Publication { get; set; }
        public int Like { get; set; }
        public string Hour { get; set; }

    }
}