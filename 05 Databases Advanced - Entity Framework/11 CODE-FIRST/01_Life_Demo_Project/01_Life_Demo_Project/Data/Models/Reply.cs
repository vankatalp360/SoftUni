namespace _01_Life_Demo_Project.Data.Models
{
    public class Reply
    {
        public Reply() { }

        protected Reply (string content)
        {
            this.Content = content;
        }

        public Reply(string content, int postId, int authorId)
            :this(content)
        {
            this.PostId = postId;
            this.AuthorId = authorId;
        }

        public Reply(string content, Post post, User author)
                : this(content)
        {
            this.Post = post;
            this.Author = author;
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
