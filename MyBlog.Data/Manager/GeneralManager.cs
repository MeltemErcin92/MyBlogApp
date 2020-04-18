using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
  public class GeneralManager : BaseManager
    {
        public GeneralManager(BlogDbContext ctx) : base(ctx)
        {
        }
        public int Sendmessage(Message m)
        {
            m.CreationDate=GetNow;
            _Context.Messages.Add(m);
            return _Context.SaveChanges();
        }
    }
}
