using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DailyRentalCost { get; set; }

        public Equipment(int equipmentId, int categoryId, string name, string description, double dailyRentalCost)
        {
            EquipmentId = equipmentId;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            DailyRentalCost = dailyRentalCost;
        }
    }

}
