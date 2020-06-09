using MyBlogApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp.Data.Manager
{
    public class BaseManager
    {
        //ProectedMetodlar sadece miras verilen sınıflardan erişilebilir 
        protected BlogDbContext _Context { get; set; }

        public BaseManager(BlogDbContext ctx)
        {
            //Eğer Dışarıdan gelen "ctx" null değilse ctx dönecek 
            //eğer null ise new BlogDbContext(DataService.ConnectionStringName); kodu çalışacak
            _Context = ctx ?? new BlogDbContext(DataService.ConnectionStringName);
        }

        public DateTime GetDateTimeNow {
            get {
                return DateTime.Now;
            }
        
        }
    }
}
