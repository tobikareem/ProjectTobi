
namespace ProjectTobi.Model
{
    public class Comment : GeneralEntity
    {
        public string UserName { get; set; }
        public string Content { get; set; }

        // public int UserId { get; set; }
        // public int BlogId { get; set; }

        // public virtual User User { get; set; }
        // public virtual Blog Blog { get; set; }
    }
}
