using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using System;
using System.Collections.Generic;

namespace ProjectTobi.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICrudRepository<Comment> crudRepository;

        public CommentService(ICrudRepository<Comment> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public void Add(Comment obj)
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

        public IEnumerable<Comment> GetAll()
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

        public Comment GetById(int id)
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

        public void Update(int id, Comment obj)
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
