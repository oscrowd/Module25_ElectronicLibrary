
using Module25_ElectronicLibrary.Entities;
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
        UserRepository userRepository = new UserRepository();
        using (AppContext app = new AppContext())
        {

            app.Database.EnsureDeleted();
            app.Database.EnsureCreated();

            User user1 = new User { Name = "user1", Email = "user1@mail.com",  Books = new List<Book>() };
            User user2 = new User { Name = "user2", Email = "user2@mail.com",  Books = new List<Book>() };
            User user3 = new User { Name = "user3", Email = "user3@mail.com", Books = new List<Book>() };
            User user4 = new User { Name = "user4", Email = "user4@mail.com",  Books = new List<Book>() };
            User user5 = new User { Name = "user5", Email = "user5@mail.com", Books = new List<Book>() };
            User user6 = new User { Name = "user6", Email = "user6@mail.com",  };
            app.Users.AddRange(user1, user2, user3, user4, user5, user6);

            app.SaveChanges();
        };
        UserContext usercontext = new UserContext(userRepository);
        usercontext.UsersActions();
        

    }

}
