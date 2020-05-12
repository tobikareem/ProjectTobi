using ProjectTobi.Interface.Repository;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

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
            using var context = services.GetService<ProjectContext>();
            var cate = GetById(id);
            cate = obj;
            context.SaveChanges();
        }

        public Category GetById(int id)
        {
            using var context = services.GetService<ProjectContext>();
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            using var context = services.GetService<ProjectContext>();
            return context.Categories.ToList();
        }

        public void Delete(int id)
        {
            using var context = services.GetService<ProjectContext>();
            var cate = GetById(id);
            context.Categories.Remove(cate);
        }
    }
}
