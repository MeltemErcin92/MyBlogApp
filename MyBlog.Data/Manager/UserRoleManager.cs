using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class UserRoleManager : BaseManager
    {
        public UserRoleManager(BlogDbContext ctx) : base(ctx)
        {
        }
        public int insertUserRole(int UserId ,int RoleId)
        {
            var result = _Context.Database.ExecuteSqlCommand(@"
declare @userId int ={0}
declare @roleId int ={1} 
insert into UserRole(UserId,RoleId) values( @userId,@roleId) ", UserId, RoleId);
            
            return result;
        }
       
        public List<Role> GetUsersRoles()
        {
            var data = _Context.Roles.ToList();
            return data;
        }
    }
}
