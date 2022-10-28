using Library.Application.Common;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.BookService.Query.GetAllBook
{
    public record GetAllQuery():IRequest<List<Book>>;
   
}
