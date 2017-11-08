namespace _01_Life_Demo_Project.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostTags
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
