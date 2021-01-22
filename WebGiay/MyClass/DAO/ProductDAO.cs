using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;

namespace MyClass.DAO
{
   public class ProductDAO
    {
        MyDBContext db = new MyDBContext();
            
        //tim kiem san pham
        public List<Giay> Searchbykey(String key)
        {
            return db.Giays.SqlQuery("Select * from Giay where tenGiay like '%" + key + "%'").ToList();
        }
        public Giay getRow(String slug)
        {
            Giay row = db.Giays.Where(m => m.slug == slug).FirstOrDefault();
            return row;
        }

        public List<Giay> getList()
        {
            List<Giay> list = db.Giays.OrderByDescending(m => m.ngayTao).ToList();
            return list;
        }
        public List<Giay> getList(String slug)
        {
            List<Giay> list = db.Giays.Where(m => m.slug == slug).ToList();
            return list;
        }
        public List<Giay> getList(int num)
        {
            List<Giay> list = db.Giays.Take(num).OrderByDescending(m => m.ngayTao).ToList();
            return list;
        }
        public List<Giay> getList2(int maloai)
        {
            List<Giay> list = db.Giays.Where(m => m.maLoai == maloai).ToList();
            return list;
        }
        //ko hieu lam :))))
        public List<Giay> getList(List<int> listcatid,int num,int id)
        {
            List<Giay> list = db.Giays
                .Where(m=>m.maGiay!=id && listcatid.Contains(m.maLoai))
            .Take(num).ToList();
            return list;
        }

        public List<Giay> getGiayHot()
        {
      
            List<int> hotSP = db.ChiTietDHs.GroupBy(d => d.maGiay)
                .Select(d => new { maGiay = d.Key, TongSL = d.Sum(s => s.soLuongMua) })
                .OrderByDescending(d => d.TongSL)
                .Select(d => d.maGiay)
                .Take(8)
                .ToList();

            var query = from hs in hotSP
                            join g in db.Giays
                            on hs equals g.maGiay
                            select new { giay = g }.giay;

            List<Giay> rs = new List<Giay>(query);

            return rs;
        }

        public List<Giay> getGiayKM()
        {
            List<KhuyenMai> KMs = db.KhuyenMais.ToList();
            List<Giay> rs = new List<Giay>();
            foreach(var km in KMs)
            {
                foreach(var item in km.Giays)
                {
                    rs.Add(item);
                }
            }
            return rs;
        }
        //lay giay theo trang
        public List<Giay> getListAll(/*string ltPhantrang,*/ int pagesize, int pagefirst)
        {
            //int total = db.Giays.Count();
            //int pageNumber = total / pagesize;
            //pageNumber = (total % pagesize != 0) ? (pageNumber++) : (pageNumber);
            //string strpageLink = "<ul>";
            //for (int i = 0; i < pageNumber; i++)
            //{
            //    strpageLink += "<li>" +
            //             "<a href='Default.aspx?option=sanpham?page="+i.ToString()+"'>" + i.ToString()+ 


            //             "</a>" +
            //        "</li>";
            //}
            //strpageLink += "</ul>";
            //ltPhantrang = strpageLink;
            List<Giay> list = db.Giays.Take(pagesize).OrderByDescending(m => m.ngayTao).Skip(pagefirst).ToList();
            return list;
        }
        //dem tong sp
        public int getCount()
        {
            int total = db.Giays.Count();
            return total;

        }
    }
}
