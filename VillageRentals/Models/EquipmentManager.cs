using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.Models
{
    public static class EquipmentManager
    {
        private static SQLiteConnection _database;
        private static List<Equipment> _equipments;
        public static List<Equipment> Equipments
        {
            get
            {
                GetAllEquipments();
                return _equipments;
            }
        }

        static EquipmentManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);
            _database.CreateTable<Equipment>();
            _equipments = new List<Equipment>();
            GetAllEquipments();
        }


        public static void GetAllEquipments()
        {
            _equipments = _database.Table<Equipment>().ToList();
        }

        public static void UpdateEquipment(Equipment equipment)
        {
            _database.Update(equipment);
        }

        public static void AddEquipment (Equipment equipment, int quantity)
        {
            equipment.Quantity += quantity;
            UpdateEquipment(equipment);
        }

        public static void RemoveEquipment (Equipment equipment, int quantity, bool isDamaged)
        {
            if (isDamaged)
            {
                equipment.DamagedQuantity += quantity;
            }

            equipment.Quantity -= quantity;
            UpdateEquipment(equipment);
        }

        public static bool IsEquipment(int equipmentId)
        {
            var equipment = _database.Table<Equipment>().FirstOrDefault(e => e.EquipmentId == equipmentId);

            if (equipment == null)
            {
                Debug.WriteLine("Equipment doesn't exist");
                return false;
            }

            return true;
        }

    }

}
