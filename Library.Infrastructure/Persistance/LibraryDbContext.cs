using Library.Domain.Entities;
using Library.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistance
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Library.Domain.Entities.Library> libraries { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=True");
        }
    }
}
