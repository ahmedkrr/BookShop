using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public Double Rate { get; private set; }
        public int TotalPages { get; private set; }
        public string PublishDate { get; private set; }
        public int BookCount { get; private set; }
        public BookStatus BookStatus { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; private set; }
        public ICollection<Order> Order { get; set; }

        public Book() { }
       
        public Book(string title, Double rate, int totalpages ,string publishdate ,int authorid ,int bookCount)
        {
            Title = title;
            Rate = rate;
            TotalPages = totalpages;
            PublishDate = publishdate;
            AuthorId = authorid;
            BookCount = bookCount;

            if (BookCount > 0)
                BookStatus = BookStatus.onStock;
            else
                BookStatus = BookStatus.outOfStock;


        }

        public void setCount(int bookCount)
        {
            BookCount = bookCount;
        }

    }

    
}
