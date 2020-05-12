using System;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class ImageRepository : ICrudRepository<Image>
    {
        private readonly IServiceProvider services;
        public ImageRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(Image obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Images.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Image obj)
        {
            using var context = services.GetService<ProjectContext>();
            var image = GetById(id);
            image = obj;
            context.SaveChanges();
        }

        public Image GetById(int id)
        {
            using var context = services.GetService<ProjectContext>();
            return context.Images.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Image> GetAll()
        {
            using var context = services.GetService<ProjectContext>();
            return context.Images.ToList();
        }

        public void Delete(int id)
        {
            using var context = services.GetService<ProjectContext>();
            var image = GetById(id);
            context.Images.Remove(image);
            context.SaveChanges();
        }
    }
}
