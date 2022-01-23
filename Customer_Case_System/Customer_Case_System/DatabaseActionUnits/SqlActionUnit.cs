using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Case_System.Data;
using Customer_Case_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Customer_Case_System.DatabaseActionUnits
{
    internal class SqlActionUnit
    {
        private readonly SqlContext _sqlContext = new SqlContext();

        public int RegisterAddress(string streetName, string postalCode, string city, string country)
        {   // returned a bool
             
            var addressToBeSaved = new Address { StreetName = streetName, PostalCode = postalCode, City = city, Country = country };
            var _databaseAddressSpecimen = _sqlContext.Addresses.Where(x =>
                x.StreetName == streetName && x.PostalCode == postalCode && x.City == city && x.Country == country).FirstOrDefault();
            if (_databaseAddressSpecimen == null)
            {

                _sqlContext.Addresses.Add(addressToBeSaved);
                _sqlContext.SaveChanges();
                
                return addressToBeSaved.Id;
            }

            else
            {
                return 0;
            }
        }

        public int RegisterCustomerToDatabase(string firstName, string lastName, int addressId)
        {
            var customerToBeSaved = new Customer { FirstName = firstName, LastName = lastName, AddressId = addressId};
            var databaseCustomerSpecimen = _sqlContext.Customers
                .Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (databaseCustomerSpecimen == null)
            {
                _sqlContext.Customers.Add(customerToBeSaved);
                _sqlContext.SaveChanges();
                return customerToBeSaved.Id;
            }

            return 0;
        }

        public void RegisterContactInfoToDatabase(string email, string primaryPhoneNumber, string secondaryPhoneNumber,
            int customerId)
        {
            var contactInfoToBeSaved = new ContactInfo { Email = email, PrimaryPhoneNumber = primaryPhoneNumber, SecondaryPhoneNumber = secondaryPhoneNumber, CustomerId = customerId};
            _sqlContext.ContactInfos.Add(contactInfoToBeSaved);
            _sqlContext.SaveChanges();
        }

        public int RegisterCaseNumber(string caseHeader, int customerId)
        {
            var caseNumberToBeSaved = new CaseNumber {Header = caseHeader, CustomerId = customerId};
            _sqlContext.CaseNumbers.Add(caseNumberToBeSaved);
            _sqlContext.SaveChanges();

            return caseNumberToBeSaved.Id;
        }

        public void RegisterCaseDetails(int caseNumberId, string caseDescription, int statusId )
        {
            
            var caseDetailsToSave = new CaseDetail
                {CaseNumbersId = caseNumberId, CaseDescription = caseDescription, RegistrationDate = DateTime.Now, DateOfLastChange = DateTime.Now ,StatusId = statusId};
            _sqlContext.CaseDetails.Add(caseDetailsToSave);
            _sqlContext.SaveChanges();
        }

        public void InitializeStatusOfCase()
        {
            var statusUnprocessedCase = new StatusOfCase {StatusOfCase1 = "Unprocessed"};
            var statusBeingProcessedCase = new StatusOfCase {StatusOfCase1 = "Being processed"};
            var statusClosedCase = new StatusOfCase {StatusOfCase1 = "Closed"};

            var unprocessedExists = _sqlContext.StatusOfCases
                .Where(x => x.StatusOfCase1 == statusUnprocessedCase.StatusOfCase1).SingleOrDefault();
            var beingProcessedExists = _sqlContext.StatusOfCases
                .Where(x => x.StatusOfCase1 == statusBeingProcessedCase.StatusOfCase1).SingleOrDefault();
            var closedExists = _sqlContext.StatusOfCases.Where(x => x.StatusOfCase1 == statusClosedCase.StatusOfCase1)
                .SingleOrDefault();
            if (unprocessedExists == null && beingProcessedExists == null && closedExists == null)
            {
                _sqlContext.StatusOfCases.AddRange(statusUnprocessedCase, statusBeingProcessedCase, statusClosedCase);
                _sqlContext.SaveChanges();
                
            }
        }
        

        
        public Address ReadAddressFromDatabase(int id)
        {
            return _sqlContext.Addresses.SingleOrDefault(x => x.Id == id);
            
        }

        public IEnumerable<Address> ReadAddressesFromDatabase()
        {
            return _sqlContext.Addresses;
        }

        public IEnumerable<Customer> ReadCustomersFromDatabase()
        {
            return _sqlContext.Customers;
        }

        public Customer ReadCustomerFromDatabase(int id)
        {
            return _sqlContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        public ContactInfo ReadContactInfoFromDatabase(int id)
        {
            return _sqlContext.ContactInfos.SingleOrDefault(x => x.CustomerId == id);
        }
        public void DeleteAddress(int id)
        
        {
            var item = _sqlContext.Addresses.Find(id);
            if (item != null && item.Id == id)
            {
                _sqlContext.Remove(item);
                _sqlContext.SaveChanges();
            }
        }

        public void UpdateAddress(int id, Address address)
        {
            var addressToBeUpdated = _sqlContext.Addresses.Find(id);
            if (addressToBeUpdated != null && addressToBeUpdated.Id == id)
            {
                addressToBeUpdated.StreetName = address.StreetName;
                addressToBeUpdated.PostalCode = address.PostalCode;
                addressToBeUpdated.City = address.City;
                addressToBeUpdated.Country = address.Country;

                _sqlContext.Update(addressToBeUpdated);
                _sqlContext.SaveChanges();
            }
        }

        public void RegisterCustomer(string firstName, string lastName, int addressId)
        {
            _sqlContext.Customers.Add(new Customer {FirstName = firstName, LastName = lastName, AddressId = addressId});
            _sqlContext.SaveChanges();
        }

        

        public List<CustomerWithContact> GetCustomersWithContact() =>
            _sqlContext.Customers.Join(
                _sqlContext.ContactInfos, // joina med
                customer => customer.Id, // ida rad
                contactInfo => contactInfo.CustomerId, // identify rad
                (customer, contactInfo) => new CustomerWithContact { FirstName = customer.FirstName, Email = contactInfo.Email }
            ).ToList();

        public List<CustomerWithPhone> GetCustomersWithPhone() =>
            _sqlContext.Customers.Join(
                _sqlContext.ContactInfos,
                customer => customer.Id,
                contactInfo => contactInfo.CustomerId,
                (customer, contactInfo) => new CustomerWithPhone
                    {Name = customer.FirstName, PrimaryPhone = contactInfo.PrimaryPhoneNumber}
            ).ToList();

        public List<CustomerWithEmail> GetCustomersWithEmail()
        {
            var customersWithEmail = (from c in _sqlContext.Customers
                    join ci in _sqlContext.ContactInfos on c.Id equals ci.CustomerId
                    select new CustomerWithEmail
                    {
                     FirstName   = c.FirstName,
                     LastName = c.LastName,
                     Email = ci.Email
                    }
                ).ToList();
            return customersWithEmail;
        }
    }




}
