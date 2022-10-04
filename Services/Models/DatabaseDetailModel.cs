using DemoProject.Services.Data.Tables;
using System.Collections.Generic;

namespace DemoProject.Services.Models
{
    public class DatabaseDetailModel
    {
        public Person Person { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
