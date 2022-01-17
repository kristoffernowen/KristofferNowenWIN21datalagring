using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Case_System.Data;
using Customer_Case_System.Models;

namespace Customer_Case_System.DatabaseActionUnits
{
    internal class SqlActionUnit
    {
        private readonly SqlContext _context = new SqlContext();

        public bool RegisterAddress(string streetName, string postalCode, string city, string country)
        {   
             
            var saveAddress = new Address();
            var _databaseAddressSpecimen = _context.Addresses.Where(x =>
                x.StreetName == streetName && x.PostalCode == postalCode && x.City == city && x.Country == country).FirstOrDefault();
            if (_databaseAddressSpecimen == null)
            {

                _context.Addresses.Add(new Address
                    {StreetName = streetName, PostalCode = postalCode, City = city, Country = country});
                _context.SaveChanges();
                saveAddress.StreetName = streetName; 
                return false;
            }

            else
            {
                return true;
            }
        }

        
        public Address ReadAddressFromDatabase(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public void RegisterCustomer(string firstName, string lastName, int addressId)
        {
            _context.Customers.Add(new Customer {FirstName = firstName, LastName = lastName, AddressId = addressId});
            _context.SaveChanges();
        }
       
    }
}
