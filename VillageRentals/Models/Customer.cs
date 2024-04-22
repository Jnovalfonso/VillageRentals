using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Customer
    {
        [Required]
        [PrimaryKey]
        public int CustomerId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
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

    }


}
