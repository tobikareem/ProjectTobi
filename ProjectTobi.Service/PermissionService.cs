
using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System.Collections.Generic;
using System;

namespace ProjectTobi.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly ICrudRepository<ApplicationRole> crudRepository;
        public PermissionService(ICrudRepository<ApplicationRole> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(ApplicationRole obj)
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

        public IEnumerable<ApplicationRole> GetAll()
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

        public ApplicationRole GetById(int id)
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

        public void Update(int id, ApplicationRole obj)
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
