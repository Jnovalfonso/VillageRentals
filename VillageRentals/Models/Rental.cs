using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalCost { get; set; }
        public List<Equipment> RentalItems { get; set; }

        public Rental(int rentalId, DateTime rentalDate, DateTime returnDate, int customerId, decimal totalCost, List<Equipment> rentalItems)
        {
            RentalId = rentalId;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            CustomerId = customerId;
            TotalCost = totalCost;
            RentalItems = rentalItems;
        }
    }
}
