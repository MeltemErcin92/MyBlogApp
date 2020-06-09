using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            var _user = _Context.Users.Where(_ => _.username == u.username && /*_.UserId == u.UserId &&*/ _.password == u.password).FirstOrDefault();
            return _user;
        } 
        public List<User> getUsers()
        {

            return _Context.Users.ToList();
        }
        public int UserDelete(int id)
        {
            var user = _Context.Users.Where(_ => _.UserId == id).FirstOrDefault();
            user.Active = false;
            return _Context.SaveChanges();
        }
        public int UpdateUser(User u)
        {
                var data = _Context.Users.Where(_ => _.UserId == u.UserId).FirstOrDefault();
                data.username = u.username;
                data.Name = u.Name;
                data.Surname = u.Surname;
                data.password = u.password;
                data.EmailAdress = u.EmailAdress;
                data.Gender = u.Gender;
                return _Context.SaveChanges();
           
           
        }
        public User getUser(int id)
        {
            var data = _Context.Users.Where(_ => _.UserId == id).FirstOrDefault();
            return data;

        }
        public int InsertUser(User u,string fullPath, HttpPostedFileBase dosya)
        {
            using (DbContextTransaction transaction=_Context.Database.BeginTransaction() )
            {
                    int etk = 0;
              
                try
                {
                
                    var user = _Context.Users.Where(_ => _.username.ToUpper() == u.username.ToUpper()).FirstOrDefault();
                    if (user != null)
                        return -1;
                    u.CreationDate = GetNow;

                   _Context.Users.Add(u);
                    etk = _Context.SaveChanges();
                    if (etk > 0)
                    {
                 dosya.SaveAs(fullPath);
                       transaction.Commit();
                       
                    }

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return 0;
                }
                return etk;

            }
              

           
           
        }
    }
}
