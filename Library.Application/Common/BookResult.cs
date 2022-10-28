using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Common
{
    public record BookResult
    (
        Guid Id,
        string Name,
        string AuthorName
    );
}
