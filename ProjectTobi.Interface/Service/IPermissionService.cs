
using ProjectTobi.Interface.Repository;
using ProjectTobi.Model;

namespace ProjectTobi.Interface.Service
{
    public interface IPermissionService: ICrudRepository<ApplicationRole>
    {
    }
}
