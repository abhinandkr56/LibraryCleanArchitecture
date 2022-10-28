using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.Persistance
{
    public interface IBookRepository
    {
        Task<bool> SaveBook(Book book);
        Task<Book> GetBookById(Guid id);
        Task<List<Book>> GetBooks();
        Task<bool> Update(Book book);
        Task<bool> Delete(Guid Id);
        Task<bool> IsBookAlreadyExist(Book book);
    }
}
