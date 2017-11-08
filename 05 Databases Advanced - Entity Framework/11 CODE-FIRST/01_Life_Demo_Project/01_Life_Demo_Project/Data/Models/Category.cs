﻿namespace _01_Life_Demo_Project.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
        }

        public Category(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
