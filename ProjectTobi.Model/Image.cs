
namespace ProjectTobi.Model
{
    /// <summary>
    /// Gets users picture archives
    /// </summary>
    public class Image : GeneralEntity
    {
        /// <summary>
        /// Gets the Name of the picture
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sets if this is a default picture
        /// </summary>
        public bool IsPrimary { get; set; }
        public byte[] Picture  { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
