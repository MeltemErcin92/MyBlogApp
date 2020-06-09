using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class CommentManager : BaseManager
    {
        public CommentManager(BlogDbContext ctx) : base(ctx)
        {

        }
        public List<Comment> AllComment()
        {
            return _Context.Comments.ToList();
        }
        public int CommentUpdate(Comment c)
        {
            var data = _Context.Comments.Where(_ => _.CommentId == c.CommentId).FirstOrDefault();
            data.isActive = c.isActive;
            return _Context.SaveChanges();
        }

    }

}
