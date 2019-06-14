using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Newsportal.Models
{
    public class Post
    {

      
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }
        [Required]
        [Display(Name = "Post Description")]
        public string PostDescription { get; set; }

       
        public DateTime AddDate { get; set; }
      
        public DateTime LastUpdate { get; set; }
        
       
        public string Image { get; set; }

        [NotMapped]
        
        public HttpPostedFileBase ImageFile { get; set; }



        public Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public List<Category> Categories { get; set; }

        //public IEnumerable<Newsportal.Models.Post> Partial { get; set; }




    }
}