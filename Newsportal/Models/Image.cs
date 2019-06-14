using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Newsportal.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

      
   
    }
}