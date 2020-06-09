using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp.Data.AppClass
{
    public class LoginResult
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

      
        public string Password { get; set; }

        public string Rememberme { get; set; }
    }
}
