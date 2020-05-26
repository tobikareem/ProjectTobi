using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System.Collections.Generic;
using System;

namespace ProjectTobi.Service
{
    public class ApplicationUserService : IUserService
    {
        private readonly ICrudRepository<ApplicationUser> crudRepository;
        public ApplicationUserService(ICrudRepository<ApplicationUser> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(ApplicationUser obj)
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

        public IEnumerable<ApplicationUser> GetAll()
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

        public ApplicationUser GetById(int id)
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

        public void Update(int id, ApplicationUser obj)
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
