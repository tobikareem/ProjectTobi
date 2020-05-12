using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System;
using System.Collections.Generic;

namespace ProjectTobi.Service
{
    public class BlogService: IBlogService
    {
        private readonly ICrudRepository<Blog> crudRepository;

        public BlogService(ICrudRepository<Blog> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(Blog obj)
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

        public IEnumerable<Blog> GetAll()
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

        public Blog GetById(int id)
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

        public void Update(int id, Blog obj)
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
