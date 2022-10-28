using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistance.BookRepo
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _bookContext = null;
        public BookRepository()
        {
            _bookContext = new LibraryDbContext();
        }
        public async Task<bool> SaveBook(Book book)
        {
            _bookContext.Add(book);
            var a = await _bookContext.SaveChangesAsync();
            return a > 0;
        }
        public async Task<Book> GetBookById(Guid id)
        {
            return _bookContext.books.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<List<Book>> GetBooks()
        {
            return _bookContext.books.ToList();
        }
        public async Task<bool> Update(Book book)
        {
            var result = _bookContext.books.SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                result.name = book.name;
                result.authorName = book.authorName;
                result.LibraryId = book.LibraryId;
                var a = await _bookContext.SaveChangesAsync();
                return a > 0;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> Delete(Guid Id)
        {
            var itemToRemove = _bookContext.books.SingleOrDefault(x => x.Id == Id);

            if (itemToRemove != null)
            {
                _bookContext.books.Remove(itemToRemove);
                var a =await _bookContext.SaveChangesAsync();
                return a > 0;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> IsBookAlreadyExist(Book book)
        {
            var a=_bookContext.books.FirstOrDefault(b=>b.name==book.name &&b.authorName == book.authorName && b.LibraryId==book.LibraryId && b.Id!=book.Id);
            
            return a != null;
        }
    }
}
