using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Internal;
using Newsportal.Dtos;
using Newsportal.Models;

namespace Newsportal.Controllers.Api
{
    public class PostsController : ApiController
    {

        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        
        //Get /api/posts -----------------------------------
        public IEnumerable<PostDto> GetPosts()
        {
            return _context.Posts.ToList().Select(Mapper.Map<Post, PostDto>);
        }
        
        //Get /api/posts/id ------------------
        public IHttpActionResult GetPost(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
                return NotFound();

            return Ok(Mapper.Map<Post, PostDto>(post));
        }

        // POST /Api/posts ----------------------------
        [HttpPost]
        public IHttpActionResult CreatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = Mapper.Map<PostDto, Post>(postDto);
            _context.Posts.Add(post);
            _context.SaveChanges();
            postDto.Id = post.Id;
            return Created(new Uri(Request.RequestUri + "/" + post.Id), postDto );

        }


        //PUT /api/posts/id ----------------------------
        [HttpPut]
        public void UpdatePost(int id, PostDto postDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var postInDb = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (postInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(postDto, postInDb);
            //postInDb.PostTitle = postDto.PostTitle;
            //postInDb.PostDescription = postDto.PostDescription;
            //postInDb.CategoryId = postDto.CategoryId;
            //postInDb.AddDate = postDto.AddDate;
            //postInDb.LastUpdate = postDto.LastUpdate;
            //postInDb.Image = postDto.Image;

            _context.SaveChanges();

        }
        //DELETE /api/posts/id
        [HttpDelete]
        public void DeletePost(int id)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (postInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Posts.Remove(postInDb);
            _context.SaveChanges();

        }
    }
}
