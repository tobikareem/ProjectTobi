using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class ImageRepository : ICrudRepository<Image>
    {
        private readonly ProjectContext context;
        public ImageRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(Image obj)
        {
            context.Images.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Image obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = System.DateTime.UtcNow;
            context.SaveChanges();
        }

        public Image GetById(int id)
           => context.Images.Find(id);

        public IEnumerable<Image> GetAll()
           => context.Images.ToList();
        

        public void Delete(int id)
        {
            var image = GetById(id);
            context.Images.Remove(image);
            context.SaveChanges();
        }
    }
}
