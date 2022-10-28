using Library.Contract.Library;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.BookService.Commands.Update
{
    public record UpdateCommand
    (
        Guid Id,
        string Name,
        string AuthorName,
        int LibraryId
    ) : IRequest<bool>;
}
