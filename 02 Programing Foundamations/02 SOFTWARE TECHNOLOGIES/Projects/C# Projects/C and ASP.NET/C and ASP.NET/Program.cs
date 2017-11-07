using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

public class Article
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime? Date { get; set; }
    public int? AuthorId { get; set; }
    public User Author { get; set; }
}
public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    public ICollection<Article> Articles { get; set; }
}

class BlogDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Article> Articles { get; set; }
}


namespace C_and_ASP.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BlogDbContext();
            var Usr1 = new User();
            Usr1.Username = "123@abv.bg";
            Usr1.FullName = "Adasd ASD ";

            var Art1 = new Article();
            Art1.Title = "asdasdasdas";
            Art1.Content = "r4ew5f54hg sghgfd   ....";
            Art1.Author = Usr1;
            db.Articles.Add(Art1);
            db.SaveChanges();
            foreach (var a in db.Articles)
            {
                Console.WriteLine($"Title: {a.Title}");
                Console.WriteLine($"Content: {a.Content}");
                Console.WriteLine($"Posted by: {a.Author?.FullName}");
            }

        }
    }


}
