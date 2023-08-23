
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Module25_ElectronicLibrary.Entities;

namespace Module25_ElectronicLibrary
{
    public class UserRepository
    {
        public void CreateUser(User user)
        {
            using (var db = new AppContext())
            {
                //db.Users.Add(new User { Name = "klim", Email = "2@2.ru" });
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
        public bool UpdateUser(int id, string name)
        {
            using (var db = new AppContext())
            {
                Entities.User userData = db.Users.Where(i => i.Id == id).FirstOrDefault();
                if (userData != null)
                {
                    userData.Name = name;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteUser(int id) 
        { 
            using (var db = new AppContext()) 
            {
                Entities.User userData = db.Users.Where(i => i.Id == id).FirstOrDefault();
                if (userData != null) 
                {
                    db.Users.Remove(userData);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<Entities.User> SelectAllUsers()
        {
            using (var db = new AppContext())
            {
                List<Entities.User> users = db.Users.ToList();
                return users.OrderBy(i => i.Id).ToList();
                
            }
        }

        public List<Entities.User> SelectUserById(int id)
        {
            using (var db = new AppContext())
            {
                List<Entities.User> users = db.Users.Where(users => users.Id == id).ToList();
                return users.OrderBy(i => i.Id).ToList();
            }
        }
    }

}
