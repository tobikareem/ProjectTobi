using ProjectTobi.Interface.Repository;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;

namespace ProjectTobi.Repository
{
    public class CategoryRepository : ICrudRepository<Category>
    {
        private readonly IServiceProvider services;

        public CategoryRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(Category obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Categories.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Category obj)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
