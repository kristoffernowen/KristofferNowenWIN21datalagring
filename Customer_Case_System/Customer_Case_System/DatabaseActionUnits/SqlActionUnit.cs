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
        {   
            var addressToBeSaved = new Address { StreetName = streetName, PostalCode = postalCode, City = city, Country = country };
            var databaseAddressSpecimen = _sqlContext.Addresses.Where(x =>
                x.StreetName == streetName && x.PostalCode == postalCode && x.City == city && x.Country == country).FirstOrDefault();

            if (databaseAddressSpecimen == null)
            {
                _sqlContext.Addresses.Add(addressToBeSaved);
                _sqlContext.SaveChanges();

                return addressToBeSaved.Id;
            }
            
            return 0;
        }

        public int RegisterCustomerToDatabase(string firstName, string lastName, int addressId)
        {
            var customerToBeSaved = new Customer { FirstName = firstName, LastName = lastName, AddressId = addressId };
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
            var contactInfoInDatabase = _sqlContext.ContactInfos.Where(x => x.Email == email).FirstOrDefault();
            var contactInfoToBeSaved = new ContactInfo { Email = email, PrimaryPhoneNumber = primaryPhoneNumber, SecondaryPhoneNumber = secondaryPhoneNumber, CustomerId = customerId };

            if (contactInfoInDatabase == null)
            {
                _sqlContext.ContactInfos.Add(contactInfoToBeSaved);
                _sqlContext.SaveChanges();
            }
        }

        public int RegisterCaseNumber(string caseHeader, int customerId)
        {
            var caseNumberToBeSaved = new CaseNumber { Header = caseHeader, CustomerId = customerId };
            _sqlContext.CaseNumbers.Add(caseNumberToBeSaved);
            _sqlContext.SaveChanges();

            return caseNumberToBeSaved.Id;
        }

        public void RegisterCaseDetails(int caseNumberId, string caseDescription, int statusId)
        {

            var caseDetailsToSave = new CaseDetail
            { CaseNumbersId = caseNumberId, CaseDescription = caseDescription, RegistrationDate = DateTime.Now, DateOfLastChange = DateTime.Now, StatusId = statusId };
            _sqlContext.CaseDetails.Add(caseDetailsToSave);
            _sqlContext.SaveChanges();
        }

        public IEnumerable<Customer> ReadCustomersFromDatabase()
        {
            return _sqlContext.Customers;
        }
       
        public IEnumerable<CustomerWithEmail> GetCustomersWithEmail()
        {
            var customersWithEmail = (from c in _sqlContext.Customers
                                      join ci in _sqlContext.ContactInfos on c.Id equals ci.CustomerId
                                      select new CustomerWithEmail
                                      {
                                          FirstName = c.FirstName,
                                          LastName = c.LastName!,
                                          Email = ci.Email
                                      }
                ).ToList();
            return customersWithEmail;
        }

        public List<CaseWithCustomerInfo> GetCasesWithCustomerInfo()
        {
            var casesWithCustomerInfo = (from caseNumbers in _sqlContext.CaseNumbers
                    join caseDetails in _sqlContext.CaseDetails on caseNumbers.Id equals caseDetails.CaseNumbersId
                    join customers in _sqlContext.Customers on caseNumbers.CustomerId equals customers.Id
                    join contactInfo in _sqlContext.ContactInfos on customers.Id equals contactInfo.CustomerId
                    join status in _sqlContext.StatusOfCases on caseDetails.StatusId equals status.Id
                    select new CaseWithCustomerInfo
                    {
                        Header = caseNumbers.Header,
                        Description = caseDetails.CaseDescription,
                        Status = status.StatusOfCase1,
                        FirstName = customers.FirstName,
                        LastName = customers.LastName,
                        Email = contactInfo.Email,
                        CreatedDate = caseDetails.RegistrationDate,
                        ModifiedDate = caseDetails.DateOfLastChange
                    }
                ).ToList();
            return casesWithCustomerInfo;
        }
    }
}
