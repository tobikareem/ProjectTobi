
using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System.Collections.Generic;
using System;

namespace ProjectTobi.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly ICrudRepository<Permission> crudRepository;
        public PermissionService(ICrudRepository<Permission> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(Permission obj)
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

        public IEnumerable<Permission> GetAll()
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

        public Permission GetById(int id)
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

        public void Update(int id, Permission obj)
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
