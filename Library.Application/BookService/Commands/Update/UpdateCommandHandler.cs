using Library.Application.BookService.Commands.Add;
using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.BookService.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Id=command.Id,
                name = command.Name,
                authorName = command.AuthorName,
                LibraryId = command.LibraryId
            };
            if (await _bookRepository.IsBookAlreadyExist(book))
            {
                throw new Exception("book already exists");
            }
            return await _bookRepository.Update(book);
        }
    }
}
