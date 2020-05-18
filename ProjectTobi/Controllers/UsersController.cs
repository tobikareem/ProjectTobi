using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;

namespace ProjectTobi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly IUserService userService;
        public UsersController(ProjectContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(userService.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public  ActionResult<User> GetUser(int id)
        {
            // var user = await _context.Users.FindAsync(id);
            var user = userService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                userService.Update(id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                var userExist = userService.GetById(id);
                if (userExist is null)
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            userService.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = userService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }

            userService.Delete(id);
            return user;
        }
    }
}
