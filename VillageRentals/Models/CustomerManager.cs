using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public class CustomerManager
    {
        private SQLiteConnection _database;
        public List<Customer> customers { get; set; }

        public CustomerManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);

            _database.CreateTable<Customer>();
        }

        public void GetAllCustomers()
        {
            customers = _database.Table<Customer>().ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _database.Insert(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _database.Update(customer);
        }

    }
}
