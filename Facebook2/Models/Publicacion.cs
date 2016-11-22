using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facebook2.Models
{
    public class Publicacion
    {
        [Key]
        public int publicationId { get; set; }
        public string User { get; set; }
        public string userimg { get; set; }
        public string Publication { get; set; }
        public string Video { get; set; }
        public string Picture { get; set; }
        public int comments { get; set; }
        public int Like { get; set; }
        string hour { get; set; }
    }
}