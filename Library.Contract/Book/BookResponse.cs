using Library.Contract.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contract.Book
{
    public record BookResponse
    (
        Guid Id,
        string Name,
        string AuthorName,
        int LibraryId
    );
}
