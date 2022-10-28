using Library.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistance.LibraryRepo
{
    public class LibraryRepository: ILibraryRepository
    {
        private LibraryDbContext _libraryContext = null;
        public LibraryRepository()
        {
            _libraryContext = new LibraryDbContext();
        }
    }
}
