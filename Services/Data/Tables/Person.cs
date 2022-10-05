using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Data.Tables
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
