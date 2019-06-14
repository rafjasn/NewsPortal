using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newsportal.Models;

namespace Newsportal.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public int PostsPerPage { get; set; }
        public int CurrentPage { get; set; }


        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Posts.Count() / (double)PostsPerPage));
        }
        public IEnumerable<Post> PaginatedPosts()
        {
            int start = (CurrentPage - 1) * PostsPerPage;
            return Posts.OrderBy(p => p.Id).Skip(start).Take(PostsPerPage);
        }
        public IEnumerable<Category> Categories { get; set; }


    }
}