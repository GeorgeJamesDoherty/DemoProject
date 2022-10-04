using System;
using System.Collections.Generic;
using System.Text;
using DemoProject.Services.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Services.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }

        public DbSet<PhoneNumber> PhoneNumber {get;set;}

        public DbSet<EmailAddress> EmailAddress { get; set; }
    }
}
