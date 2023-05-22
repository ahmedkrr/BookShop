using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookModel
    {
      
    }
    public enum BookStatus
    {
        undefined = 0,
        onStock = 1,
        outOfStock = 2

    }
    public class AddBookModel
    {
        public string Title { get;  set; }
        public int TotalPages { get; set; }
        public string PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int BookCount { get; set; }
        public Double Rate { get; set; }
    }

    public class GetAllBooksResponse
    {
        public int Id {get; set;}
        public string Title { get;  set; }
        public Double Rate { get;  set; }
        public int TotalPages { get; set; }
        public string PublishDate { get; set; }
        public string AuthorName { get; set; }
    }


} 
