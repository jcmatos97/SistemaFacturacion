﻿using System.Web;
using System.Web.Optimization;

namespace SistemaFacturacionInventario
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/bootstrap-datetimepicker.mim.js",
                       "~/Scripts/bootstrap-switch.min.js",
                       "~/Scripts/charts.js",
                       "~/Scripts/custom.js",
                       "~/Scripts/excanvas.min.js",
                       "~/Scripts/filter.js",
                       "~/Scripts/fullcalendar.min.js",
                       "~/Scripts/jquery.cleditor.min.js",
                       "~/Scripts/jquery.flot.js",
                       "~/Scripts/jquery.flot.pie.js",
                       "~/Scripts/jquery.flot.resize.js",
                       "~/Scripts/jquery.flot.stack.js",
                       "~/Scripts/jquery.prettyPhoto.js",
                       "~/Scripts/jquery.rateit.min.js",
                       "~/Scripts/sparklines.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-datetimepicker.min.css",
                    "~/Content/bootstrap-switch.css",
                    "~/Content/fullcalendar.css",
                    "~/Content/jquery.cleditor.css",
                    "~/Content/jquery-ui.css",
                    "~/Content/prettyPhoto.css", 
                    "~/Content/rateit.css",
                    "~/Content/site.css",
                    "~/Content/style.css",
                    "~/Content/widgets.css",
                    "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                    "~/Content/font-awesome-4.7.0/css/font-awesome.css"
                      ));
        }
    }
}
