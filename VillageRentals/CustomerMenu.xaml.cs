using VillageRentals.Models;

namespace VillageRentals;

public partial class CustomerMenu : ContentPage
{
	public CustomerMenu()
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
        CustomerManager customerManager = new CustomerManager();
        customerManager.GetAllCustomers();
        customerCollection.ItemsSource = customerManager.customers;
    }
    private void OnAddCustomerClicked(object sender, EventArgs e)
	{
		MainButton.IsVisible = false;
		customerCollection.IsVisible = false;
		addCustomerPage.IsVisible = true;
	}

    private void OnSubmitClicked(object sender, EventArgs e)
    {
		if (string.IsNullOrEmpty(firstNameEntry.Text) ||
			string.IsNullOrEmpty(lastNameEntry.Text) ||
			string.IsNullOrEmpty(contactPhoneEntry.Text) ||
			string.IsNullOrEmpty(emailEntry.Text))
		{
			DisplayAlert("All fields must be filled", "The customer information has not been completely filled out, please, fill all the information.", "OK");
			return;
		}

		Customer newCustomer = new Customer(lastNameEntry.Text, firstNameEntry.Text, contactPhoneEntry.Text, emailEntry.Text);
        CustomerManager customerManager = new CustomerManager();
		customerManager.AddCustomer(newCustomer);

        MainButton.IsVisible = true;
        customerCollection.IsVisible = true;
        addCustomerPage.IsVisible = false;

    }
}