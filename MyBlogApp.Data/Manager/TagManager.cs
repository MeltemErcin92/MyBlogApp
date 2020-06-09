using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogApp.Data.Model;

namespace MyBlogApp.Data.Manager
{
    public class TagManager : BaseManager
    {
        //Tag ile alakalı Database İşlemleri 
        public TagManager(BlogDbContext ctx) : base(ctx)
        {
        }

        public List<Tag> GetAllTags()
        {
            //string sqlQuery = "Select * from Tag";
            //var tags = _Context.Database.SqlQuery<Tag>(sqlQuery).ToList();
           var tags  = _Context.Tags.ToList();
            return tags;
        }


        public List<Article> GetArticles(int tagId)
        {
            return  _Context.Articles
                    .Where(_ => _.Tags.Any(t => t.TagId == tagId))
                    .ToList();
            
            //Join ile Sql Query ile yapılacak 
        }
    }
}
