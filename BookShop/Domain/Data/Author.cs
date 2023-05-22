using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; private set; }
        public ICollection<Book> Books { get; set; }

        public Author()
        {

        }
        public Author(string name)
        {
            AuthorName = name;
        }
    }
}
