using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogApp.Data.AppClass;
using MyBlogApp.Data.Model;

namespace MyBlogApp.Data.Manager
{
    public class UserManager : BaseManager
    {
        public UserManager(BlogDbContext ctx) : base(ctx)
        {
        }

        public User CheckUser(LoginResult u) {

            User user = _Context.Users.Where
                                      (_ => _.UserName == u.UserName && _.Password == u.Password)
                                      .FirstOrDefault();
            return user;
        }
    }
}
