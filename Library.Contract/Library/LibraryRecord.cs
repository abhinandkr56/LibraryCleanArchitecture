using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contract.Library
{
    public record LibraryRecord
    (
        int Id,
        string Name,
        string Location
    );
}
