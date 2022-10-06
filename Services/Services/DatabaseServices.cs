using DemoProject.Services.Data;
using DemoProject.Services.Data.Tables;
using DemoProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Services.Services
{
    public class DatabaseServices
    {
        //constants to avoid 'Magic Strings'
        private const string PersonStr = "Person";
        private const string NumberStr = "Number";
        private const string EmailStr = "Email";

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

        //Detail page setup using 'Custom Where filer method'
        public DatabaseDetailModel DetailSetup(int personId)
        {
            var model = new DatabaseDetailModel();
            //model.PhoneNumbers = _demoContext.PhoneNumber.Where(x => x.PersonId == personId).ToList();
            model.PhoneNumbers = _demoContext.PhoneNumber.CustomWhere(x => x.PersonId == personId).ToList();
            //model.EmailAddresses = _demoContext.EmailAddress.Where(x => x.PersonId == personId).ToList();
            model.EmailAddresses = _demoContext.EmailAddress.CustomWhere(x => x.PersonId == personId).ToList();
            //model.Person = _demoContext.Person.Where(x => x.Id == personId).FirstOrDefault();
            model.Person = _demoContext.Person.CustomWhere(x => x.Id == personId).FirstOrDefault();
            return model;
        }

        //Add new person
        public bool AddPerson(DatabaseDetailModel model)
        {
            try
            {
                var person = new Person()
                {
                    FirstName = model.Person.FirstName,
                    LastName = model.Person.LastName
                };

                var contactBase = new ContactInfoBase()
                {
                    PersonId = person.Id,
                    IsActive = true,
                    DateAdded = DateTime.UtcNow
                };

                person.EmailAddresses = model.EmailAddresses.Where(x => !String.IsNullOrEmpty(x.Email)).Select(x => new EmailAddress(contactBase) { Email = x.Email }).ToList();
                person.PhoneNumbers = model.PhoneNumbers.Where(x => !String.IsNullOrEmpty(x.Number)).Select(x => new PhoneNumber(contactBase) { Number = x.Number }).ToList();

                _demoContext.Person.Add(person);

                _demoContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        //Add Contact information
        public bool AddContact(DatabaseDetailModel model)
        {
            string type = !String.IsNullOrEmpty(model.NewEmailAddress) ? EmailStr : NumberStr;
            var contactInfo = new ContactInfoBase()
            {
                PersonId = model.Person.Id,
                IsActive = true,
                DateAdded = DateTime.UtcNow
            };
            switch (type)
            {
                case EmailStr:
                    _demoContext.EmailAddress.Add(new EmailAddress(contactInfo)
                    {
                        Email = model.NewEmailAddress
                    });
                    break;
                case NumberStr:
                    _demoContext.PhoneNumber.Add(new PhoneNumber(contactInfo)
                    {
                        Number = model.NewPhoneNumber
                    });
                    break;
                default:
                    return false;
            }
            _demoContext.SaveChanges();
            return true;
        }

        //Delete from database
        public bool Delete(string type, int id)
        {
            switch (type)
            {
                case PersonStr:
                    _demoContext.Person.Remove(_demoContext.Person.FirstOrDefault(x => x.Id == id));
                    break;
                case EmailStr:
                    _demoContext.EmailAddress.Remove(_demoContext.EmailAddress.FirstOrDefault(x => x.Id == id));
                    break;
                case NumberStr:
                    _demoContext.PhoneNumber.Remove(_demoContext.PhoneNumber.FirstOrDefault(x => x.Id == id));
                    break;
                default:
                    return false;
            }
            _demoContext.SaveChanges();
            return true;
        }
    }
}
