using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public int IsBanned { get; set; }

        public Customer()
        {
            
        }
        public Customer(int customerId, string lastName, string firstName, string contactPhone, string email, int isBanned)
        {
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            ContactPhone = contactPhone;
            Email = email;
            IsBanned = isBanned;
        }

        public Customer(string lastName, string firstName, string contactPhone, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            ContactPhone = contactPhone;
            Email = email;
        }
    }


}
