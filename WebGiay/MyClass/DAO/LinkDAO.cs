using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;

namespace MyClass.DAO
{
   public class LinkDAO
    {
        MyDBContext db = new MyDBContext();

        public List<Link> getList()
        {
            List<Link> link = db.Links.ToList();
            return link;
        }

        public Link getRow(String slug)
        {
            Link row = db.Links.Where(p => p.slug == slug).FirstOrDefault();
            return row;
        }
    }
}
