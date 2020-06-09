using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.AppClass;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class RoleManager : BaseManager
    {
        public RoleManager(BlogDbContext ctx) : base(ctx)
        {

        }
       public List<Role> getRoles()
        {
            return _Context.Database.SqlQuery<Role>(@"
                                            select * from Role
                                            Where IsActive = 1").ToList();
    
         
        }
       public User CheckUser(LoginResult u)
        {
            var _user = _Context.Users.Where(_ => _.username == u.username && /*_.UserId == u.UserId &&*/ _.password == u.password).FirstOrDefault();
            return _user;
        } 
        public List<User> getUsers()
        {

            return _Context.Users.ToList();
        }
        //public int UserDelete(int id)
        //{
        //    var user = _Context.Users.Where(_ => _.UserId == id).FirstOrDefault();
        //    user.Active = false;
        //    return _Context.SaveChanges();
        //}
        public int RoleDelete(int id)
        {
            var role = _Context.Roles.Where(_ => _.RoleId == id).FirstOrDefault();
            role.IsActive =false;
            return _Context.SaveChanges();
        }

        //public int UpdateUser(User u)
        //{
        //    var data = _Context.Users.Where(_ => _.UserId == u.UserId).FirstOrDefault();
        //    data.username = u.username;
        //    data.Name = u.Name;
        //    data.Surname = u.Surname;
        //    data.password = u.password;
        //    data.EmailAdress = u.EmailAdress;
        //    data.Gender = u.Gender;
        //    return _Context.SaveChanges();


        //}
        public int UpdateRole(Role r)
        {
            var data = _Context.Roles.Where(_ => _.RoleId == r.RoleId).FirstOrDefault();
            data.RoleName = r.RoleName;
            return _Context.SaveChanges();


        }

        //public User getUser(int id)
        //{
        //    var data = _Context.Users.Where(_ => _.UserId == id).FirstOrDefault();
        //    return data;

        //}
        //public int InsertUser(User u)
        //{
        //    var user = _Context.Users.Where(_ => _.username.ToUpper() == u.username.ToUpper()).FirstOrDefault();

        //    if (user != null)
        //        return -1;
        //    u.CreationDate = GetNow;
        //    _Context.Users.Add(u);
        //    return _Context.SaveChanges();
        //}
        public int roleInsert(Role r)
        {
            try
            {

                var rol = _Context.Roles.Where(_ => _.RoleName.ToUpper() == r.RoleName.ToUpper()).FirstOrDefault();

                if (rol != null)
                    return -1;
                r.CreationDate = GetNow;
                _Context.Roles.Add(r);
                return _Context.SaveChanges();
            }
            catch(Exception e)
            {
           return   0;
            }
          
           
        }
         
      
    }
}
