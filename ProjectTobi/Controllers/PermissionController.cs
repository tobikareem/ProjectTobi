using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;

namespace ProjectTobi.Controllers
{
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        // GET: api/Permission
        [HttpGet]
        public ActionResult<IEnumerable<Permission>> GetPermissions()
        {
            return Ok(permissionService.GetAll());
        }

        // GET: api/Permission/5
        [HttpGet("{id}")]
        public ActionResult<Permission> GetPermission(int id)
        {
            var permission = permissionService.GetById(id);

            if (permission is null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        // PUT: api/Permission/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutPermission(int id, Permission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }
            try
            {
                permissionService.Update(id, permission);
            }
            catch (DbUpdateConcurrencyException)
            {
                var permissionExist = permissionService.GetById(id);
                if (permissionExist is null)
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

        // POST: api/Permission
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Permission> PostPermission(Permission permission)
        {
            permissionService.Add(permission);
            return CreatedAtAction("GetPermission", new { id = permission.Id }, permission);
        }

        // DELETE: api/Permission/5
        [HttpDelete("{id}")]
        public ActionResult<Permission> DeletePermission(int id)
        {
            var permission = permissionService.GetById(id);
            if (permission is null)
            {
                return NotFound();
            }

            permissionService.Delete(id);
            return permission;
        }
    }
}
