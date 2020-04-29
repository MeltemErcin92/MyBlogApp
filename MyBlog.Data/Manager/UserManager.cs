using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.AppClass;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class UserManager : BaseManager
    {
        public UserManager(BlogDbContext ctx) : base(ctx)
        {
        }
       public User CheckUser(LoginResult u)
        {
            var _user = _Context.Users.Where(_ => _.username == u.username /*&& _.UserId == u.UserId*/ && _.password == u.password).FirstOrDefault();
            return _user;
        } 
    }
}
