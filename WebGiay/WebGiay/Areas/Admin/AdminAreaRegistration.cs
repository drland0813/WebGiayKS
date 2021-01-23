﻿using System.Web.Mvc;

namespace WebGiay.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_Login",
                "Admin/login",
                new { Controller = "Auth", action = "Login", id = UrlParameter.Optional }
            );
            context.MapRoute(
               "Admin_Logout",
               "Admin/logout",
               new { Controller = "Auth", action = "Logout", id = UrlParameter.Optional }
           );


            context.MapRoute(
               name: "AdminLienHe",
               url: "Admin/lien-he",
               defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "WebGiay.Areas.Admin.Controllers" }
           );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller="Dashboard" ,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}