using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Data
{
    public class ContactInfoBase
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
