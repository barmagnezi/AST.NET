using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class PostComments
    {
        public  Post post;
        public IQueryable<Comment> comments;
        public int numberOfCom;
        public Comment newComment;
    }
}