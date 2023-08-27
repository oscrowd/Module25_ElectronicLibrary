using Module25_ElectronicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module25_ElectronicLibrary
{
    public class BookContext
    {
        private BookRepository _BookRepository;
        public BookContext(BookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }
        public void BooksActions()
        {
            string action = string.Empty;
            do
            {
                //Console.WriteLine("Доступные действия:\n'show': показать всех пользователей данные;\n'showone': выбрать пользователя по id;\n'add': добавить пользователя;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
                Console.WriteLine("Доступные действия для книг:\n'show': показать все книги;\n'showone': выбрать книгу по id;\n'add': добавить книгу;\n'delete': удалить по Id;\n'update': изменить название книги;\n'exit': выход\n");
                Console.WriteLine("\n'autcount': кол-во книг автора;\n'gencount': кол-во книг жанра;\n'ubcount': колво книг у пользователя;\n'bookexist': наличие книги \n'lastbook': новейшая книга;\n'yearorderdesc': список книг по дате выхода\n");
                Console.WriteLine("\n'titleorder': все книги, отсортированные по названию;\n'genyearexist': наличие книг жанра за период;\n'ubexist': есть ли id книги у id читателя;");
                Console.Write("\nВведите нужное действие: ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "show":
                        List<Book> list =_BookRepository.SelectAllBooks();
                        list.ForEach(x => Console.WriteLine(x.Id + " " + x.Title + " " + x.Genre + " " + x.AuthorSurname));
                        break;
                    case "showone":
                        int idTemp;
                        Console.Write("Введите id книги");
                        bool result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            list = _BookRepository.SelectBookById(idTemp);
                            list.ForEach(x => Console.WriteLine(x.Id + " " + x.Title + " " + x.Genre + " " + x.AuthorSurname));
                        }
                        else Console.WriteLine("Введено не числовое значение, операция выборки книги прервана");
                        break;
                    case "add":
                        Entities.Book Book = new Entities.Book();
                        Console.WriteLine("Введите новое название книги: ");
                        Book.Title = Console.ReadLine();
                        Console.WriteLine("Введите жанр книги: ");
                        Book.Genre = Console.ReadLine();
                        _BookRepository.CreateBook(Book);
                        Console.WriteLine("Книга создана");
                        break;
                    case "del":
                        bool successDel=false;
                        Console.Write("Введите id пользователя");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            successDel = _BookRepository.DeleteBook(idTemp);
                        }
                        else Console.WriteLine("Введено не числовое значение, операция удаления книги прервана");
                        if (successDel)
                        {
                            Console.WriteLine("Книга {0} удалена", idTemp);
                        }
                        else Console.WriteLine("Книга {0} не найдена", idTemp);
                        break;
                    case "upd":
                        bool successUpd = false;
                        Console.Write("Введите id книги");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            Console.WriteLine("Введите Название книги: ");
                            string BookName = Console.ReadLine();
                            successUpd = _BookRepository.UpdateBook(idTemp, BookName);
                        }
                        else
                        {
                            Console.WriteLine("Введено не числовое значение, операция обновления названия книги прервана");
                            break;
                        }
                        if (successUpd)
                        {
                            Console.WriteLine("Книга {0} обновлена", idTemp);
                        }
                        else Console.WriteLine("Книга {0} не найдена", idTemp);
                        break;
                    case "autcount":
                        Console.Write("Введите фамилию автора");
                        string autor = Console.ReadLine();
                        int autorCount = _BookRepository.SelectAutorCount(autor);
                        Console.WriteLine("Количество книг автора {0}: {1}", autor,autorCount);
                        break;
                    case "genrecount":
                        Console.Write("Введите фамилию автора");
                        string genre = Console.ReadLine();
                        int genreCount = _BookRepository.SelectGenreCount(genre);
                        Console.WriteLine("Количество книг автора {0}: {1}", genre, genreCount);
                        break;
                    case "ubcount":
                        Console.Write("Введите id пользователя");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            int UBCount = _BookRepository.SelectUserHaveBookCount(idTemp);
                            Console.WriteLine("У пользователя {0} на руках {1} книг", idTemp, UBCount);
                        }
                        else
                        {
                            Console.WriteLine("Введено не числовое значение, операция прервана");
                            break;
                        }
                        break;
                    case "bookexist":
                        Console.Write("Введите фамилию автора");
                        autor = Console.ReadLine();
                        Console.WriteLine("Введите новое название книги: ");
                        string title = Console.ReadLine();
                        bool bookexist = _BookRepository.ExistTitleAutor(autor, title);
                        if (bookexist)
                            Console.WriteLine("Книга {0} автора {1} есть в библиотеке", title, autor);
                        else
                            Console.WriteLine("Книги {0} автора {1} нет в библиотеке", title, autor);
                        break;
                    case "lastbook":
                        Book book = _BookRepository.SelectLastBook();
                        Console.WriteLine(book.Title + " " + book.Genre + " " + book.AuthorSurname + " " + book.YearOfRelease);
                        break;
                    case "yeardesc":
                        list = _BookRepository.SelectBookOrderByYearDesc();
                        list.ForEach(x => Console.WriteLine(x.Id + " " + x.Title + " " + x.Genre + " " + x.AuthorSurname + " " + x.YearOfRelease ));
                        break;
                    case "titleorder":
                        list = _BookRepository.SelectBookOrderByYearDesc();
                        list.ForEach(x => Console.WriteLine(x.Id + " " + x.Title + " " + x.Genre + " " + x.AuthorSurname + " " + x.YearOfRelease));
                        break;
                    case "autyearexist":
                        int year1, year2;
                        Console.Write("Введите название жанра");
                        genre = Console.ReadLine();
                        Console.WriteLine("Введите год начала периода: ");
                        result = Int32.TryParse(Console.ReadLine(), out year1);
                        Console.WriteLine("Введите год окончания периода: ");
                        bool result2 = Int32.TryParse(Console.ReadLine(), out year2);

                        if (result & result2)
                        {
                            list = _BookRepository.SelectGenreAndYearList(genre, year1, year2);
                            if (list.Count == 0)
                                Console.WriteLine("Книги жанра {0} не найдены", genre);
                            else list.ForEach(x => Console.WriteLine(x.Id + " " + x.Title + " " + x.Genre + " " + x.AuthorSurname));
                        }
                        else Console.WriteLine("Введено не числовое значение в периоде. Вводить надо в формате yyyy, Например, 1982");
                        break;
                    case "ubexist":
                        int idTemp2;
                        Console.Write("Введите id пользователя");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        Console.Write("Введите id книги");
                        result2 = Int32.TryParse(Console.ReadLine(), out idTemp2);
                        if (result & result2)
                        {
                            bool successFind = _BookRepository.SelectBookOnHandle(idTemp, idTemp2);
                            if (successFind)
                                Console.WriteLine("Книга {0} на руках у пользователя {1}", idTemp2, idTemp);
                            else Console.WriteLine("Книга {0} не на руках у пользователя {1}", idTemp2, idTemp);
                        }
                        else Console.WriteLine("Введено не числовое значение id пользователя и/или книги");
                        
                        break;
                }
                Console.ReadLine();
            }
            while (action != "exit");
        }
    }
}
