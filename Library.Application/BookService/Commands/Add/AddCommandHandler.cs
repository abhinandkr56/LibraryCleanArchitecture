using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.BookService.Commands.Add
{
    public class AddCommandHandler : IRequestHandler<AddCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public AddCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(AddCommand command, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                name = command.Name,
                authorName = command.AuthorName,
                LibraryId=command.LibraryId
            };
            if (await _bookRepository.IsBookAlreadyExist(book))
            {
                throw new Exception("book already exists");
            }
            return await _bookRepository.SaveBook(book);
        }
    }
}
