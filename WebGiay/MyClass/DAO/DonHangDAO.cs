using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;
namespace MyClass.DAO
{
    public class DonHangDAO
    {

        public void addDH(DonHang donHang)
        {
            MyDBContext context = new MyDBContext();
            
            context.DonHangs.Add(donHang);
            //context.DonHangs.Attach(donHang);

            foreach (var item in donHang.ChiTietDHs)
            {
                context.ChiTietDHs.Add(item);
                context.ChiTietDHs.Attach(item);
                ChiTietGiay ctg = context.ChiTietGiays.FirstOrDefault(k => k.maGiay == item.maGiay) as ChiTietGiay;
                ctg.soLuongTon -= item.soLuongMua;
            }

            context.SaveChanges();
        }
    }
}
