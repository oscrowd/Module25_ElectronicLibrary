
using Module25_ElectronicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Module25_ElectronicLibrary;

class Program
{
    static void Main(string[] args)
    {
        UserRepository userRepository = new UserRepository();
        BookRepository bookRepository = new BookRepository();
        using (AppContext app = new AppContext())
        {

            app.Database.EnsureDeleted();
            app.Database.EnsureCreated();

            User user1 = new User { Name = "user1", Email = "1@mail.com", Books = new List<Book>() };
            User user2 = new User { Name = "user2", Email = "2@mail.com", Books = new List<Book>() };
            User user3 = new User { Name = "user3", Email = "3@mail.com", Books = new List<Book>() };
            User user4 = new User { Name = "user4", Email = "4@mail.com", Books = new List<Book>() };
            User user5 = new User { Name = "user5", Email = "5@mail.com", Books = new List<Book>() };
            User user6 = new User { Name = "user6", Email = "6@mail.com", };
            app.Users.AddRange(user1, user2, user3, user4, user5, user6);

            Book book1 = new Book { Title = "Недоросль", Genre = "комедия", AuthorSurname = "Фонвизин", YearOfRelease = 1782, User = user1 };
            Book book2 = new Book { Title = "Обыкновенное чудо", Genre = "Фэнтези", AuthorSurname = "Шварц", YearOfRelease = 1956, User = user5 };
            Book book3 = new Book { Title = "Горе от ума", Genre = "комедия", AuthorSurname = "Грибоедов", YearOfRelease = 1825, User = user1 };
            Book book4 = new Book { Title = "Пикник на обочине", Genre = "научная фантастика", AuthorSurname = "Стругацкие", YearOfRelease = 1972, User = user5 };
            Book book5 = new Book { Title = "Затерянный мир", Genre = "приключения", AuthorSurname = "Дойль", YearOfRelease = 1912, User = user2 };
            Book book6 = new Book { Title = "Метро 2034", Genre = "постапокалиптический роман", AuthorSurname = "Глуховский", YearOfRelease = 2009, User = user2 };
            Book book7 = new Book { Title = "Пятнадцатилетний капитан", Genre = "приключения", AuthorSurname = "Верн", YearOfRelease = 1878, User = user4 };
            Book book8 = new Book { Title = "Улитка на склоне", Genre = "антиутопия", AuthorSurname = "Стругацкие", YearOfRelease = 1966, User = user4 };
            Book book9 = new Book { Title = "Богач, бедняк", Genre = "роман", AuthorSurname = "Шоу", YearOfRelease = 1969, User = user4 };
            Book book10 = new Book { Title = "Град обреченный", Genre = "антиутопия", AuthorSurname = "Стругацкие", YearOfRelease = 1975, User = user3 };
            Book book11 = new Book { Title = "Сказка о царе Салтане", Genre = "сказка", AuthorSurname = "Пушкин", YearOfRelease = 1831 };
            app.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11);
            app.SaveChanges();
        };
        string action;
        do
        {
            //Console.WriteLine("Доступные действия:\n'show': показать всех пользователей данные;\n'showone': выбрать пользователя по id;\n'add': добавить пользователя;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
            Console.WriteLine("Доступные действия:\n'users': действия с читателями;\n'books': действия с пользователями;\n'exit': выход");
            Console.Write("\nВведите нужное действие: ");
            action = Console.ReadLine();
            UserContext usercontext = new UserContext(userRepository);
            BookContext bookcontext = new BookContext(bookRepository);
            switch (action)
            {
                case "users":
                    usercontext.UsersActions();
                    break;
                case "books":
                    bookcontext.BooksActions();
                    break;
            }

        }
        while (action != "exit");

    }
}
