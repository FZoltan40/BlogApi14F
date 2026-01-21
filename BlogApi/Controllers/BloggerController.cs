using BlogApi.Models;
using BlogApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewBlogger(AddBloggerDto addBloggerDto)
        {
            using (var context = new BlogContext())
            {
                var blogger = new Blogger
                {
                    Name = addBloggerDto.Name,
                    Email = addBloggerDto.Email,
                    RegTime = DateTime.Now,
               
                };

                context.Bloggers.Add(blogger);
                context.SaveChanges();

                return StatusCode(201, blogger);
            }
               
        }

        [HttpGet]
        public ActionResult GetAllBlogger()
        {
            using (var context = new BlogContext())
            {
                var blogger = context.Bloggers.ToList();
                return StatusCode(200, blogger);
            }
        }

        [HttpGet("byid")]
        public ActionResult GetBlogger(int id) 
        {
            using (var context = new BlogContext())
            {
                var exsitingBlogger = context.Bloggers.FirstOrDefault(x => x.Id == id);
                
                if (exsitingBlogger != null)
                {
                    return StatusCode(200, exsitingBlogger);
                }

                return StatusCode(404, null);
            }
        }

        [HttpDelete]
        public ActionResult DeletBlogger(int id)
        {
            using (var context = new BlogContext())
            {
                var exsitingBlogger = context.Bloggers.FirstOrDefault(x => x.Id == id);

                if(exsitingBlogger != null)
                {
                    context.Bloggers.Remove(exsitingBlogger);
                    context.SaveChanges();
                    return StatusCode(200, exsitingBlogger);
                }
                return StatusCode(404, null);
            }
        }

        [HttpPut]
        public ActionResult UpdateBlogger(int id, UpdateBloggerDto updateBloggerDto)
        {
            using (var context = new BlogContext())
            {
                var exsitingBlogger = context.Bloggers.FirstOrDefault(x => x.Id == id);

                if (exsitingBlogger != null)
                {
                    exsitingBlogger.Name = updateBloggerDto.Name;
                    exsitingBlogger.Email = updateBloggerDto.Email;
                    exsitingBlogger.ModTime = DateTime.Now;

                    context.Bloggers.Update(exsitingBlogger);
                    context.SaveChanges();
                    return StatusCode(200, exsitingBlogger);

                }
                return StatusCode(404, null);
            }
        }
    }
}
