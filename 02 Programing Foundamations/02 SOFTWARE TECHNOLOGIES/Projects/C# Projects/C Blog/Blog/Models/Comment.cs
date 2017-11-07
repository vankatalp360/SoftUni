﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CommentText { get; set; }

        [ForeignKey("Article")]
        public string ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime Date { get; set; }

        public Comment()
        {
            this.Date = DateTime.Now;
        }

        public bool isAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }
    }
}