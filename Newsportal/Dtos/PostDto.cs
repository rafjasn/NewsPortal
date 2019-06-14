using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newsportal.Models;

namespace Newsportal.Dtos
{
    public class PostDto
    {
     
            [Required] public int Id { get; set; }

            [Required]
            [Display(Name = "Post Title")]
            public string PostTitle { get; set; }

            [Required]
            public string PostDescription { get; set; }

             public DateTime AddDate { get; set; }
            public DateTime LastUpdate { get; set; }
            [Required] public string Image { get; set; }

            //public Category Category { get; set; }

           public int CategoryId { get; set; }

        

    }
}