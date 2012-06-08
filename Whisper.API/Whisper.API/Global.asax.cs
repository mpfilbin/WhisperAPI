using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Whisper.API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                 name: "CheckinApi",
                 routeTemplate: "api/location/checkin/{studentId}/{courseid}/{lat}/{lon}",
                 defaults: new { controller = "Location", action = "Checkin", studentId = UrlParameter.Optional, courseid = UrlParameter.Optional, lat = UrlParameter.Optional, lon = UrlParameter.Optional }
             );

            routes.MapHttpRoute(
                 name: "GetStudent",
                 routeTemplate: "api/students/{token}/{id}",
                 defaults: new { controller = "Students", action = "GetStudent", token = UrlParameter.Optional, id = UrlParameter.Optional }
             );

            routes.MapHttpRoute(
                 name: "GetStudentCourses",
                 routeTemplate: "api/courses/students/{token}/{id}",
                 defaults: new { controller = "Courses", action = "Student", token = UrlParameter.Optional, id = UrlParameter.Optional }
             );

            routes.MapHttpRoute(
                 name: "GetCourseCheckins",
                 routeTemplate: "api/checkins/course/{token}/{id}",
                 defaults: new { controller = "Checkins", action = "Course", token = UrlParameter.Optional, id = UrlParameter.Optional }
             );

            routes.MapHttpRoute(
               name: "Signin",
               routeTemplate: "api/signin",
               defaults: new { controller = "Signin", action = "Authenticate" }
           );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}