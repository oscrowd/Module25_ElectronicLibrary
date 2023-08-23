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
        public string YearOfRelease { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<Book>? Books { get; set; }
    }
}
