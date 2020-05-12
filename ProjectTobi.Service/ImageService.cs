using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System;
using System.Collections.Generic;

namespace ProjectTobi.Service
{
    public class ImageService : IImageService
    {
        private readonly ICrudRepository<Image> crudRepository;

        public ImageService(ICrudRepository<Image> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(Image obj)
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

        public IEnumerable<Image> GetAll()
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

        public Image GetById(int id)
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

        public void Update(int id, Image obj)
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
