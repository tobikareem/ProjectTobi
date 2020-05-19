
namespace ProjectTobi.Model
{
    public class UserPermission : GeneralEntity
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }


        // public virtual User User { get; set; }
        // public virtual Permission Permission { get; set; }
    }
}
