using System.Collections.Generic;

namespace ProjectTobi.Model
{
    public class Blog : GeneralEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }


        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
