using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.AppClass
{
  public   class LoginResult
    {
        public int UserId { get; set; }

       
        public string username { get; set; }

       
        public string Name { get; set; }

  
        public string Surname { get; set; }

    
        public string password { get; set; }

        public string remember { get; set; }
    }
}
