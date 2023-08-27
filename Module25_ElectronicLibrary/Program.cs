
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

            Book book1 = new Book { Title = "20000 лье под водой", Genre = "Научная фантастика", AuthorSurname = "Верн", YearOfRelease = 1870, User = user1 };
            Book book2 = new Book { Title = "Ведьмак", Genre = "Фэнтези", AuthorSurname = "Сапковский", YearOfRelease = 1993, User = user5 };
            Book book3 = new Book { Title = "Горе от ума", Genre = "Комедия", AuthorSurname = "Грибоедов", YearOfRelease = 1825, User = user1 };
            Book book4 = new Book { Title = "Пикник на обочине", Genre = "Научная фантастика", AuthorSurname = "Стругацкие", YearOfRelease = 1972, User = user5 };
            Book book5 = new Book { Title = "Метро 2033", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfRelease = 2005, User = user2 };
            Book book6 = new Book { Title = "Метро 2034", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfRelease = 2009, User = user2 };
            Book book7 = new Book { Title = "Метро 2035", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfRelease = 2015, User = user4 };
            Book book8 = new Book { Title = "Война и мир", Genre = "Роман", AuthorSurname = "Толстой", YearOfRelease = 1869, User = user4 };
            Book book9 = new Book { Title = "Золотой телёнок", Genre = "Сатира", AuthorSurname = "Ильф и Петров", YearOfRelease = 1931, User = user4 };
            Book book10 = new Book { Title = "Автостопом по галактике", Genre = "Фэнтези", AuthorSurname = "Дуглас", YearOfRelease = 1979, User = user3 };
            Book book11 = new Book { Title = "Какое-то", Genre = "Какоё-то", AuthorSurname = "Кто-то", YearOfRelease = 0001 };
            app.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11);

            app.SaveChanges();
        };
        UserContext usercontext = new UserContext(userRepository);
        usercontext.UsersActions();
        

    }

}
