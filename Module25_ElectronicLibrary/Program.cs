
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Module25_ElectronicLibrary;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            // Использование EF
            var user1 = new User { Name = "Arthur", Email = "1@1.ru" };
            var user2 = new User { Name = "klim", Email = "2@2.ru"};

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
        }
    }

}
