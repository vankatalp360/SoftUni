namespace _01_Life_Demo_Project.Data.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        { }

        public Tag(string name)
        {
            this.Name = name;
        }
        public int Id;
        public string Name;

        public ICollection<Post> Post = new List<Post>();

        public ICollection<PostTags> PostTags { get; set; }
    }
}
