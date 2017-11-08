
namespace _01_Life_Demo_Project.Data.Models
{
    using System.Collections.Generic;

    public class Post
    {
        public Post() { }

        private Post(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public Post(string title, string content, User author , Category category)
            :this( title,  content)
        {
            this.Author = author;
            this.Category = category;
        }

        public Post(string title, string content, int authorId, int categoryId)
             : this(title, content)
        {
            this.AuthorId = authorId;
            this.CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();

        public ICollection<PostTags> PostTags { get; set; }
    }
}
