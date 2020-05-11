using ProjectTobi.Interface.Repository;
using ProjectTobi.Model;

namespace ProjectTobi.Service
{
    public class UserService
    {
        private readonly ICrudRepository<User> crudRepository;
        public UserService(ICrudRepository<User> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(User obj)
        {
            crudRepository.Add(obj);
        }
    }
}
