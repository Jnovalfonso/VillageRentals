﻿using Microsoft.Maui.Controls;

namespace VillageRentals
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CustomerMenu), typeof(CustomerMenu));
            Routing.RegisterRoute(nameof(InventoryMenu), typeof(InventoryMenu));
            Routing.RegisterRoute(nameof(RentalMenu), typeof(RentalMenu));
        }
    }
}
