using DemoProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Data.Tables
{
    public class PhoneNumber : ContactInfoBase
    {
        public PhoneNumber() { }

        public PhoneNumber(ContactInfoBase contactInfoBase)
        {
            Id = contactInfoBase.Id;
            PersonId = contactInfoBase.PersonId;
            IsActive = contactInfoBase.IsActive;
            DateAdded = contactInfoBase.DateAdded;
        }

        public string Number { get; set; }
    }
}
