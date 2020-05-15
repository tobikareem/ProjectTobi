using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;

namespace ProjectTobi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: api/Comment
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            return Ok(commentService.GetAll());
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = commentService.GetById(id);

            if (comment is null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            try
            {
                commentService.Update(id, comment);
            }
            catch (DbUpdateConcurrencyException)
            {
                var commentExists = commentService.GetById(id);
                if (commentExists is null)
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

        // POST: api/Comment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Comment> PostComment(Comment comment)
        {
            commentService.Add(comment);
            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public ActionResult<Comment> DeleteComment(int id)
        {
            var comment = commentService.GetById(id);
            if (comment is null)
            {
                return NotFound();
            }

            commentService.Delete(id);
            return comment;
        }
    }
}
