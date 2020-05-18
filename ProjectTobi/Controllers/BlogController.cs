using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;

namespace ProjectTobi.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        // GET: api/Blog
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetBlogs()
        {
            return Ok(blogService.GetAll());
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(int id)
        {
            var blog = blogService.GetById(id);

            if (blog is null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT: api/Blog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            try
            {
                blogService.Update(id, blog);
            }
            catch (DbUpdateConcurrencyException)
            {
                var blogExists = blogService.GetById(id);
                if (blogExists is null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Blog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Blog> PostBlog(Blog blog)
        {
            blogService.Add(blog);
            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public ActionResult<Blog> DeleteBlog(int id)
        {
            var blog = blogService.GetById(id);
            if (blog is null)
            {
                return NotFound();
            }
            blogService.Delete(id);
            return blog;
        }
    }
}
