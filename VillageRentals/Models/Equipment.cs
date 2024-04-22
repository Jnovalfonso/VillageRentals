using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Equipment
    {
        [Required]
        [PrimaryKey]
        public int EquipmentId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double DailyRentalCost { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int DamagedQuantity { get; set; }

        public Equipment()
        {
            
        }
        public Equipment(int equipmentId, int categoryId, string name, string description, double dailyRentalCost, int quantity, int damagedQuantity)
        {
            EquipmentId = equipmentId;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            DailyRentalCost = dailyRentalCost;
            Quantity = quantity;
            DamagedQuantity = damagedQuantity;
        }
    }

}
