using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public static class RentalManager
    {
        public static int currentId;
        private static SQLiteConnection _database;
        private static List<Rental> _rentals;

        public static List<Rental> Rentals
        {
            get
            {
                GetAllRentals();
                return _rentals;
            }
        }

        static RentalManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);
            _database.CreateTable<Rental>();
            _rentals = new List<Rental>();
            GetAllRentals();
            GetLastRental();
        }

        public static void GetAllRentals()
        {
            _rentals = _database.Table<Rental>().ToList();
        }

        public static void GetLastRental()
        {
            Rental lastRental = _database.Table<Rental>().OrderByDescending(r => r.RentalId).FirstOrDefault();
            currentId = lastRental.RentalId + 1;
        }

        public static void AddRental(Rental rental)
        {
            _database.Insert(rental);
        }        
    }
}
