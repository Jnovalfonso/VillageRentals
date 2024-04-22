using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Rental
    {

        [Required]
        [PrimaryKey]
        public int RentalId { get; set; }

        [Required]
        public string RentalDate { get; set; }

        [Required]
        public string ReturnDate { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        public Rental()
        {
            
        }

        public Rental(int rentalId, string rentalDate, string returnDate, double totalCost, int customerId, int equipmentId)
        {
            RentalId = rentalId;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            CustomerId = customerId;
            TotalCost = totalCost;
            CustomerId = customerId;
            EquipmentId = equipmentId;
        }
    }
}
