using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsportal.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public DateTime CommenDate { get; set; }
        public int ParentId { get; set; }









    }


}