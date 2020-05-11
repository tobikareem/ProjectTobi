
using System.Collections.Generic;

namespace ProjectTobi.Model
{
    public class User : GeneralEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
