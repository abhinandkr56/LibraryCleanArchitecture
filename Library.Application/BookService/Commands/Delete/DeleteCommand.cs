using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.BookService.Commands.Delete
{
    public record DeleteCommand
    (
        Guid Id
    ):IRequest<bool>;
    
}
