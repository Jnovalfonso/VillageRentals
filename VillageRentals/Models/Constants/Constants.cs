using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class Constants
    {
        public const string DatabaseFile = "Database\\VillageRentalsDB.db";

        public static string DbPath =>
         Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
         @"..\..\..\..\..\", DatabaseFile);
    }
}
