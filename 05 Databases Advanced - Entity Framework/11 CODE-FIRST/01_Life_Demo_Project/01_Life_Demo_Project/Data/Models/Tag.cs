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
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PostTags> PostTags { get; set; }
    }
}
