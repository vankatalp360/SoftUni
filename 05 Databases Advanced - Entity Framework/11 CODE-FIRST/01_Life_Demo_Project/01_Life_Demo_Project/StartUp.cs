namespace _01_Life_Demo_Project
{
    using System;
    using _01_Life_Demo_Project.Data;
    using _01_Life_Demo_Project.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var context = new ForumDbContent();

            ResetDBContext(context);

            PrintResultWithSelect(context);
            //PrintResultWithInclude(context);

        }

        private static void PrintResultWithSelect(ForumDbContent context)
        {
            var categories = context
                            .Categories
                            .Select(c => new
                            {
                                c.Name,
                                Posts = c.Posts
                                .Select(p => new
                                {
                                    p.Title,
                                    p.Content,
                                    p.Author,
                                    Replies = p.Replies
                                    .Select(r => new
                                    {
                                        r.Content,
                                        r.Author
                                    }),
                                    Tags = p.PostTags
                                    .Select(pt=>pt.Tag.Name)
                                })
                            });
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Name}");

                foreach (var p in c.Posts)
                {
                    Console.WriteLine($"Title: {p.Title}");
                    Console.WriteLine($"Content: {p.Content}");
                    Console.WriteLine($"---Written by: {p.Author.Username}");

                    foreach (var r in p.Replies)
                    {
                        Console.WriteLine($"---- Reply Content:{r.Content} --by:{r.Author.Username}");
                    }
                    //foreach (var t in p.Tags)
                    //{
                    //    Console.WriteLine($"Tag:{t}");
                    //}
                    Console.WriteLine($"----Tags: {string.Join(" / ", p.Tags)}");
                }
            }
        }

        private static void PrintResultWithInclude(ForumDbContent context)
        {
            var categories = context
                .Categories
                .Include(c => c.Posts)
                .ThenInclude(p => p.Replies)
                .ThenInclude(r => r.Author)
                .ToList();
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Name}");

                foreach (var p in c.Posts)
                {
                    Console.WriteLine($"Title: {p.Title}");
                    Console.WriteLine($"Content: {p.Content}");
                    Console.WriteLine($"--- by: {p.Author.Username}");

                    foreach (var r in p.Replies)
                    {
                        Console.WriteLine($"Content:{r.Content} --by:{r.Author.Username}");
                    }
                }
            }
        }

        private static void ResetDBContext(ForumDbContent context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(ForumDbContent context)
        {
            var users = new[]
                        {
                new User ("gosho", "123"),
                new User ("pesho", "123"),
                new User ("ivan", "678"),
                new User ("dragan", "3254"),
                new User ("miroslav", "456"),
                new User("stan", "ewr")
            };

            context.Users.AddRange(users);

            context.SaveChanges();

            var categories = new[]
            {
                new Category("C#"),
                new Category("Java"),
                new Category("Encoding"),
                new Category("Crypting")
            };

            context.Categories.AddRange(categories);

            var posts = new[]
            {
                new Post ("C# Coding", "FUNDAMENTALS OF COMPUTER PROGRAMMING WITH C# (The Bulgarian C# Programming Book)",1,1),
                new Post ("Java Coding", "FUNDAMENTALS OF COMPUTER PROGRAMMING WITH Java (The Bulgarian Java Programming Book)",2,2),
                new Post ("Basic Encoding SHA1", "SHA1 encoding.........",1,3),
                new Post ("Basic Encoding MD5", "MD5 encoding.........",2,3),
                new  Post ("Basic Crypting MD5", "MD5 Crypting......",3,4),
                new  Post ("Crypting 2017", "2017 Crypting..........",4,4)
            };

            context.Posts.AddRange(posts);

            var replies = new[]
            {
                new Reply ("I am Pesho. I am learning C# Basic ......",posts[0],users[0]),
                new Reply ("I am Gosho. I am learning Java Basic ......",posts[1],users[1]),
                new Reply ("I am Gosho. I want to learn C# Basic ......",posts[0],users[1])
            };

            context.Replies.AddRange(replies);

            var tags = new[]
            {
                new Tag("C#"),
                new Tag("Java"),
                new Tag("learn"),
                new Tag("Basic")
            };

            context.Tags.AddRange(tags);

            context.SaveChanges();

            var postTags = new[]
            {
                new PostTags(){ PostId=1, TagId=1},
                new PostTags(){ PostId=1, TagId=3}
            };

            context.PostTags.AddRange(postTags);

            context.SaveChanges();
        }
    }
}
