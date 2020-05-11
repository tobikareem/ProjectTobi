using System;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using Microsoft.Extensions.DependencyInjection;

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
            throw new System.NotImplementedException();
        }

        public Image GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Image> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
