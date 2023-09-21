using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obl_opgave_1
{
    public class BooksRepository
    {
        private int _idnext=1;

        private List<Book> library=new();

        public BooksRepository()
        {
            {
                library.Add(new Book { Id = _idnext++, Title = "string bean", Price = 250 });
                library.Add(new Book { Id = _idnext++, Title = "Den røde død", Price = 300 });
                library.Add(new Book { Id = _idnext++, Title = "Game of Thrones", Price = 350 });
                library.Add(new Book { Id = _idnext++, Title = "Bibel", Price = 150 });
                library.Add(new Book { Id = _idnext++, Title = "Cool beans", Price = 200 });
            }
            
        }

        public List<Book> Get(int? price=null,string? orderby=null)
        {
            IEnumerable<Book> result=new List<Book>(library);
            if (price != null)
            {
                result=result.Where(book => book.Price > price);
            }
            if(orderby!=null)
            {
                result = orderby switch
                {
                    "Name" => result.OrderBy(result => result.Title),
                    "NameDesc" => result.OrderByDescending(result => result.Title),
                    "Price" => result.OrderBy(result => result.Price),
                    "PriceDesc" => result.OrderByDescending(result => result.Price),
                    _=> throw new ArgumentException("invalid order")

                } ;
            }
            return result.ToList();
        }

        public Book GetByID(int id)
        {
            foreach(Book book in library) 
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book Add(Book book)
        {
            book.Id = _idnext++;
            return book;
        }

        public Book Delete(int id)
        {
            Book deletebook = GetByID(id);
            if(deletebook!= null && deletebook.Id==id)
            {
                library.Remove(deletebook);
                return deletebook;
            }
            return null;
            
        }

        public Book Update(int id,Book book)
        {
            Book oldBook = GetByID(id);
            if(oldBook==null)
            {
                return null;
            }
            oldBook.Id = id;
            oldBook.Title = book.Title;
            oldBook.Price = book.Price;
            return oldBook;
        }
    }
}
