using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Post
    {
        public long id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string urlAuthor { get; set; }
        public string date{ get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public string video { get; set; }
        public List<Comment> comments { get; set; }
    }

    public class PostDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}