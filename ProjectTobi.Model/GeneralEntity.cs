
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTobi.Model
{
    [NotMapped]
    public class GeneralEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
