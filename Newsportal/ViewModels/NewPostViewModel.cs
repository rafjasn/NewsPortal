using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newsportal.Models;

namespace Newsportal.ViewModels
{
    public class NewPostViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Post Post { get; set; }


    }
}