using VillageRentals.Models;

namespace VillageRentals;

public partial class InventoryMenu : ContentPage
{
    Equipment currentEquipment;
	public InventoryMenu()
	{
		InitializeComponent();
        UpdatePage();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdatePage();
    }

    private void UpdatePage()
    {
        equipmentCollection.ItemsSource = EquipmentManager.Equipments;
        addQuantityEntry.Text = string.Empty;
        removeQuantityEntry.Text = string.Empty;
    }

    private void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        equipmentCollection.IsVisible = false;
        removeEquipmentPage.IsVisible = true;
        var button = (Button)sender;
        var equipment = (Equipment)button.BindingContext;
        currentEquipment = equipment;
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        equipmentCollection.IsVisible = false;
        addEquipmentPage.IsVisible = true;
        var button = (Button)sender;
        var equipment = (Equipment)button.BindingContext;
        currentEquipment = equipment;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        if (int.TryParse(addQuantityEntry.Text, out int quantity))
        {
            if (quantity <= 0)
            {
                DisplayAlert("Error", "Please enter a quantity greater than 0.", "OK");
                return;
            }

            EquipmentManager.AddEquipment(currentEquipment, quantity);
            
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid quantity.", "OK");
            return;
        }

        equipmentCollection.IsVisible = true;
        addEquipmentPage.IsVisible = false;

        UpdatePage();
    }

    private void OnRemoveClicked(object sender, EventArgs e)
    {
        if (int.TryParse(removeQuantityEntry.Text, out int quantity))
        {
            bool isDamaged = picker.SelectedIndex == 0; // 0 for "Send To Damaged Equipment", 1 for "Remove from Inventory"

            if (quantity <= 0)
            {
                DisplayAlert("Error", "Please enter a quantity greater than 0.", "OK");
                return;
            }

            if (quantity > currentEquipment.Quantity)
            {
                DisplayAlert("Error", $"Quantity cannot be greater than available: {currentEquipment.Quantity}", "OK");
                return;
            }

            EquipmentManager.RemoveEquipment(currentEquipment, quantity, isDamaged);          
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid quantity.", "OK");
            return;
        }

        equipmentCollection.IsVisible = true;
        removeEquipmentPage.IsVisible = false;

        UpdatePage();
    }
}
