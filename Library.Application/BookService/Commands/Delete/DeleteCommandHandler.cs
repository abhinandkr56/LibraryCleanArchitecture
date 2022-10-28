using Library.Application.BookService.Commands.Update;
using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.BookService.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
{
            return await _bookRepository.Delete(request.Id);
        }
    }
}
