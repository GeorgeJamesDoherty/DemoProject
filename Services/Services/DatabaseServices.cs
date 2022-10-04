using DemoProject.Services.Data;
using DemoProject.Services.Data.Tables;
using DemoProject.Services.Models;
using System;
using System.Linq;

namespace DemoProject.Services.Services
{
    public class DatabaseServices
    {
        private readonly DemoContext _demoContext;

        public DatabaseServices(DemoContext demoContext) 
        {
            _demoContext = demoContext;
        }

        public DatabaseIndexModel Setup()
        {
            var model = new DatabaseIndexModel();
            model.people = _demoContext.Person.ToList();
            return model;
        }

        public DatabaseDetailModel DetailSetup(int personId)
        {
            var model = new DatabaseDetailModel();
            model.PhoneNumbers = _demoContext.PhoneNumber.Where(x => x.PersonId == personId).ToList();
            model.EmailAddresses = _demoContext.EmailAddress.Where(x => x.PersonId == personId).ToList();
            model.Person = _demoContext.Person.Where(x => x.Id == personId).FirstOrDefault();
            return model;
        }

        public bool AddPerson(DatabaseDetailModel model)
        {
            try
            {
                var person = new Person()
                {
                    FirstName = model.Person.FirstName,
                    LastName = model.Person.LastName
                };
                _demoContext.Person.Add(person);
                _demoContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
