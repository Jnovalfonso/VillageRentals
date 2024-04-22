using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public Category(int categoryId, string description)
        {
            CategoryId = categoryId;
            Description = description;
        }
    }
}
