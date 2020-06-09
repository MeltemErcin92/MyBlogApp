using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogApp.Data.Model;

namespace MyBlogApp.Data.Manager
{
    public class GeneralManager : BaseManager
    {
        public GeneralManager(BlogDbContext ctx) : base(ctx)
        {
        }

        public int SendMessage(Message msg) {

            msg.CreationDate = GetDateTimeNow;
            _Context.Messages.Add(msg);
            return _Context.SaveChanges();
        }
    }
}
