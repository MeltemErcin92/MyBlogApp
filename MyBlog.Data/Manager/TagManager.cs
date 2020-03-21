using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class TagManager : BaseManager
    {
        public TagManager(BlogDbContext ctx) : base(ctx)
        {
        }
        public List<Tag> GetAllTags()
        {
            string sqlQuery = "select * from Tag";
            return _Context.Database.SqlQuery<Tag>(sqlQuery).ToList();
        }
    }
}
