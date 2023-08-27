using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_ElectronicLibrary.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int YearOfRelease { get; set; }
        public string AuthorSurname { get; set; }
        //public int YearOfIssue { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<Book>? Books { get; set; }
    }
}
