using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebGiay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "GioiThieu",
              url: "gioi-thieu",
              defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                       name: "XacDinhSize",
                       url: "xac-dinh-size-giay",
                       defaults: new { controller = "XacDinhSize", action = "Index", id = UrlParameter.Optional }
                   );
            routes.MapRoute(
                     name: "ChiTietSanPham1",
                     url: "jordan-1-low-grey-camo",
                     defaults: new { controller = "ChiTietSanPham1", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute(
                 name: "TinTuc",
                 url: "tin-tuc",
                 defaults: new { controller = "TinTuc", action = "Index", id = UrlParameter.Optional }
             );
            routes.MapRoute(
             name: "DanhMucSanPham",
             url: "loai-san-pham",
             defaults: new { controller = "DanhMucSanPham", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
         name: "DangNhap",
         url: "dang-nhap",
         defaults: new { controller = "KhachHang", action = "DangNhap", id = UrlParameter.Optional }
     );
            routes.MapRoute(
         name: "DangKy",
         url: "dang-ky",
         defaults: new { controller = "KhachHang", action = "DangKy", id = UrlParameter.Optional }
     );
            routes.MapRoute(
         name: "DangXuat",
         url: "dang-xuat",
         defaults: new { controller = "KhachHang", action = "DangXuat", id = UrlParameter.Optional }
     );
            routes.MapRoute(
                name: "GioHang",
                 url: "gio-hang",
                 defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional }
);

            routes.MapRoute(
    name: "SiteSlug",
     url: "{slug}",
     defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
    );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
