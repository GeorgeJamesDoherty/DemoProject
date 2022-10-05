using DemoProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Data.Tables
{
    public class EmailAddress : ContactInfoBase
    {
        public EmailAddress() { }

        public EmailAddress(ContactInfoBase contactInfoBase)
        {
            Id = contactInfoBase.Id;
            PersonId = contactInfoBase.PersonId;
            IsActive = contactInfoBase.IsActive;
            DateAdded = contactInfoBase.DateAdded;
        }

        public string Email { get; set; }
    }
}
