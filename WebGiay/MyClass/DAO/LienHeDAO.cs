using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;
namespace MyClass.DAO
{
    public class LienHeDAO
    {
        MyDBContext context = null;
        public void AddLH(LienHe lh)
        {
            context = new MyDBContext();
            context.LienHes.Add(lh);
            context.SaveChanges();
        }
    }
}
