using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System;
using System.Collections.Generic;

namespace ProjectTobi.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICrudRepository<Category> crudRepository;
        public CategoryService(ICrudRepository<Category> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(Category obj)
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

        public IEnumerable<Category> GetAll()
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

        public Category GetById(int id)
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

        public void Update(int id, Category obj)
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
