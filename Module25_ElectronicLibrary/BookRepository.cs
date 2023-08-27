
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Module25_ElectronicLibrary.Entities;

namespace Module25_ElectronicLibrary
{
    public class BookRepository
    {
        public void CreateBook(Book book)
        {
            using (var db = new AppContext())
            {
                //db.Users.Add(new User { Name = "klim", Email = "2@2.ru" });
                db.Books.Add(book);
                db.SaveChanges();
            }

        }
        public bool UpdateBook(int id, string title)
        {
            using (var db = new AppContext())
            {
                Entities.Book bookData = db.Books.Where(i => i.Id == id).FirstOrDefault();
                if (bookData != null)
                {
                    bookData.Title = title;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteBook(int id) 
        { 
            using (var db = new AppContext()) 
            {
                Entities.Book bookData = db.Books.Where(i => i.Id == id).FirstOrDefault();
                if (bookData != null) 
                {
                    db.Books.Remove(bookData);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<Entities.Book> SelectAllBooks()
        {
            using (var db = new AppContext())
            {
                List<Entities.Book> books = db.Books.ToList();
                return books.OrderBy(i => i.Id).ToList();
                
            }
        }

        public List<Entities.Book> SelectBookById(int id)
        {
            using (var db = new AppContext())
            {
                List<Entities.Book> books = db.Books.Where(books => books.Id == id).ToList();
                return books.OrderBy(i => i.Id).ToList();
            }
        }

        public List<Entities.Book> SelectGenreList(string genre)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => b.Genre.ToUpper() == genre).ToList();
                return books.OrderBy(i => i.Id).ToList();
            }
                
        }

        public int SelectGenreCount(string genre)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => b.Genre.ToUpper() == genre).ToList();
                return books.Count;
            }
        }
        public int SelectAutorCount(string autor)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => b.AuthorSurname.ToUpper() == autor).ToList();
                return books.Count;
            }
        }

        public bool ExistTitleAutor(string title, string autor)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => (b.AuthorSurname.ToUpper() == autor && b.Title.ToUpper() == title)).ToList();
                if (books.Count == 0)
                    return true;
                else return false;
            }
        }

        public int SelectUserHaveBookCount(int idUser)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => b.UserId == idUser).ToList();
                return books.Count;
            }
        }
        public Book SelectLastBook()
        {
            using (var db = new AppContext())
            {
                
                List<Entities.Book> books = db.Books.ToList();
                books.OrderByDescending(i => i.YearOfRelease).ToList();
                Book book = books.FirstOrDefault();
                return book;
            }
        }

        public List<Entities.Book> SelectAllBooksOrderByTitle()
        {
            using (var db = new AppContext())
            {
                List<Entities.Book> books = db.Books.ToList();
                return books.OrderBy(i => i.Title).ToList();

            }
        }

        public List<Entities.Book> SelectBookOrderByYearDesc()
        {
            using (var db = new AppContext())
            {

                List<Entities.Book> books = db.Books.ToList();
                return books.OrderByDescending(i => i.YearOfRelease).ToList();
            }
        }
        public bool SelectBookOnHandle(int uerId, int bookId)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => (b.Id == bookId && b.UserId == uerId)).ToList();
                if (books.Count > 0)
                    return true;
                else return false;
            }

        }

        public List<Entities.Book> SelectGenreAndYearList(string genre, int year1, int year2)
        {
            using (var db = new AppContext())
            {
                List<Book> books = db.Books.Where(b => (b.Genre.ToUpper() == genre && b.YearOfRelease>=year1 && b.YearOfRelease<=year2)).ToList();
                return books.OrderBy(i => i.Id).ToList();
            }

        }

    }

}
