using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using MyClass.Model;
using MyClass.DAO;

namespace MyClass.DAO
{
    public class AccountDAO
    {
        MyDBContext db = null;   
        public AccountDAO()
        {
            db = new MyDBContext();
        }
        public Account getRow(string str)
        {

            Account row = db.Accounts.Where(p => p.index_quyen != 0 && p.email == str).FirstOrDefault();
            return row;
        }

        public void addAccount(Account ac)
        {
            db = new MyDBContext();
            db.Accounts.Add(ac);
            db.SaveChanges();

        }
    }
}
