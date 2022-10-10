using DemoProject.Services.Data.Tables;
using System.Collections.Generic;

namespace DemoProject.Services.Models.ViewModels
{
    public class DatabaseDetailModel
    {
        public Person Person { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }

        public string NewEmailAddress { get; set; }

        public string NewPhoneNumber { get; set; }
    }
}
