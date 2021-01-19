using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;

namespace MyClass.DAO
{
   public class SlideDAO
    {
        MyDBContext db = new MyDBContext();

        public List<Slider> getList(String position)
        {
            List<Slider> list = db.Sliders.Where(p => p.viTri == position && p.trangThai == 1).ToList();
            return list;
        }

       
    }
}
