using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Data.Tables
{
    public class EmailAddress
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
