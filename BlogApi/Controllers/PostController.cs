using BlogApi.Models;
using BlogApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogContext _context;
        public PostController(BlogContext context) 
        { 
            _context = context;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddNewPost(AddPostDto addPostDto)
        {
            var post = new Post
            {
                Title = addPostDto.Title,
                Post1 = addPostDto.Post1,
                Bloggerid = addPostDto.Bloggerid,
                RegTime = DateTime.Now,
           
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return StatusCode(201,post);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            //var posts = await _context.Posts.ToListAsync();
            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (post != null) 
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Sikeres törrlés" , result = post });
            }
            return NotFound(new { message = "Sikertelen törlés!", result = post});
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePost(int id, UpdatePostDto updatePostDto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (post != null)
            {
                post.Title = updatePostDto.Title;
                post.Post1 = updatePostDto.Post1;
                post.ModTime = DateTime.Now;

                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Sikeres módoítás!", result = post });
            }
            return NotFound(new { message = "Sikertelen módoítás!", result = post });
        }
    }
}
