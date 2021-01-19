using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;

namespace MyClass.DAO
{
   public class SizeDAO
    {
        MyDBContext db = new MyDBContext();

        public List<Size> getList()
        {
            List<Size> link = db.Sizes.ToList();
            return link;
        }
    }
}
