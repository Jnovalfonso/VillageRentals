using System.Diagnostics;
using VillageRentals.Models;

namespace VillageRentals;

public partial class RentalMenu : ContentPage
{
    public RentalMenu()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdatePage();
    }

    private void UpdatePage()
    {
        rentalCollection.ItemsSource = RentalManager.Rentals;
    }

    private void OnNewRentalClicked(object sender, EventArgs e)
    {
        rentalCollection.IsVisible = false;
        addRentalPage.IsVisible = true;
        MainButton.IsVisible = false;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(customerIdEntry.Text) ||
        string.IsNullOrWhiteSpace(equipmentIdEntry.Text) ||
        rentalDatePicker.Date == DateTime.MinValue ||
        returnDatePicker.Date == DateTime.MinValue ||
        string.IsNullOrWhiteSpace(costEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        DateTime rentalDate = rentalDatePicker.Date;
        DateTime returnDate = returnDatePicker.Date;

        string formattedRentalDate = rentalDate.ToString("yyyy-MM-dd");
        string formattedReturnDate = returnDate.ToString("yyyy-MM-dd");

        int customerId;
        if (!int.TryParse(customerIdEntry.Text, out customerId) ||
            !CustomerManager.IsCustomer(customerId))
        {
            DisplayAlert("Error", "Invalid customer ID.", "OK");
            return;
        }

        int equipmentId;
        if (!int.TryParse(equipmentIdEntry.Text, out equipmentId) ||
            !EquipmentManager.IsEquipment(equipmentId))
        {
            DisplayAlert("Error", "Invalid equipment ID.", "OK");
            return;
        }

        double totalCost;
        if (!double.TryParse(costEntry.Text, out totalCost))
        {
            DisplayAlert("Error", "Invalid Total Cost value.", "OK");
            return;
        }

        Rental rental = new Rental(RentalManager.currentId, formattedRentalDate, formattedReturnDate, totalCost, customerId, equipmentId);
        RentalManager.AddRental(rental);

        MainButton.IsVisible = true;
        rentalCollection.IsVisible = true;
        addRentalPage.IsVisible = false;

        rentalCollection.ItemsSource = RentalManager.Rentals;
        RentalManager.GetLastRental();

    }
}