using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System.Collections.Generic;
using System;

namespace ProjectTobi.Service
{
    public class UserService : IUserService
    {
        private readonly ICrudRepository<User> crudRepository;
        public UserService(ICrudRepository<User> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(User obj)
        {
            try
            {
                crudRepository.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                crudRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return crudRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetById(int id)
        {
            try
            {
                return crudRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(int id, User obj)
        {
            try
            {
                crudRepository.Update(id, obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
