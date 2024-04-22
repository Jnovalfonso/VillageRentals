using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public static class CustomerManager
    {
        private static SQLiteConnection _database;
        private static List<Customer> _customers;
        public static List<Customer> customers
        {
            get
            {
                GetAllCustomers();
                return _customers;
            }
        }

        public static int currentId;

        static CustomerManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);
            _database.CreateTable<Customer>();
            _customers = new List<Customer>();
            GetAllCustomers();
            GetLastCustomer();
        }

        public static void GetLastCustomer()
        {
            Customer lastCustomer = _database.Table<Customer>().OrderByDescending(c => c.CustomerId).FirstOrDefault();
            currentId = lastCustomer.CustomerId + 1;
        }

        public static void GetAllCustomers()
        {
            _customers = _database.Table<Customer>().ToList();
        }

        public static void AddCustomer(Customer customer)
        {
            _database.Insert(customer);
            customers.Add(customer);
        }

        public static void UpdateCustomer(Customer customer)
        {
            _database.Update(customer);
        }

        public static bool IsCustomer(int customerId)
        {
            var customer = _database.Table<Customer>().FirstOrDefault(c => c.CustomerId == customerId);


            if (customer == null)
            {
                Debug.WriteLine("Customer doesn't exist");
                return false;
            }

            return true;
        }
    }

}
