using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public EFContext()
        {

        }

        public EFContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MVC3;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
