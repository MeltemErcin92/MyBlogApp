using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogAppUI.Helpers
{
    public class Helper
    {
        public static string ShortenContent(string data)
        {
            return data.Length > 300 ? data.Substring(0, 300) : data;
             
        }
    }
}