using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;
namespace MyClass.DAO
{
   public class PostDAO
    {
        MyDBContext db = new MyDBContext();

        public List<BaiViet> getList()
        {
            List<BaiViet> link = db.BaiViets.OrderByDescending(m=>m.ngayDang).ToList();
            return link;
        }

        public BaiViet getRow(String slug)
        {
            BaiViet row = db.BaiViets.Where(p => p.slug == slug).FirstOrDefault();
            return row;
        }

        public List<BaiViet> getList(int num)
        {
            List<BaiViet> list = db.BaiViets.Take(num).OrderByDescending(m => m.ngayDang).ToList();
            return list;
        }
    }
}
