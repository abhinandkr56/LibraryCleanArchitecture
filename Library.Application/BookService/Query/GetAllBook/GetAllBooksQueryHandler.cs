using Library.Application.Common;
using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.BookService.Query.GetAllBook
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooks();
        }
    }
}
