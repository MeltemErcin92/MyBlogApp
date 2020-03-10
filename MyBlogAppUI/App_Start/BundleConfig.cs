using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyBlogAppUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/LayoutScript").Include
                (
                "~/Content/style/js/bootstrap.min.js",
               "~/Content/style/js/jquery.min.js",
               "~/Content/style/js/plugins.js",
               "~/Content/style/js/scripts.js")

               );

            bundles.Add(new StyleBundle("~/Content/LayoutCss")
                .Include("~/Content/style/css/bootstrap.min.css",
                "~/Content/style/css/plugins.css",
                "~/Content/style.css",
                 "~/Content/style/css/color/red.css",
                  "~/Content/style/type/bebas.css",
                  "~/Content/style/type/fontello.css"


                )
                );
          
        }
       

    }


}