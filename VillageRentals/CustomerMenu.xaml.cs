using System.Diagnostics;
using VillageRentals.Models;

namespace VillageRentals;

public partial class CustomerMenu : ContentPage
{
    Customer updateCustomer;
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
        customerCollection.ItemsSource = CustomerManager.customers;
    }
    private void OnAddCustomerClicked(object sender, EventArgs e)
	{
		MainButton.IsVisible = false;
		customerCollection.IsVisible = false;
		addCustomerPage.IsVisible = true;
	}

    private void OnUpdateCustomerClicked(object sender, EventArgs e)
    {
        MainButton.IsVisible = false;
        customerCollection.IsVisible = false;
        updateCustomerPage.IsVisible = true; 

        var button = (Button)sender;
        var customer = (Customer)button.BindingContext;
        updateCustomer = customer;

        firstNameEntryUpdate.Text = customer.FirstName;
        lastNameEntryUpdate.Text = customer.LastName;
        contactPhoneEntryUpdate.Text = customer.ContactPhone;
        emailEntryUpdate.Text = customer.Email;
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

		Customer newCustomer = new Customer(CustomerManager.currentId, lastNameEntry.Text, firstNameEntry.Text, contactPhoneEntry.Text, emailEntry.Text, 0);
		CustomerManager.currentId += 1;
		CustomerManager.AddCustomer(newCustomer);

        MainButton.IsVisible = true;
        customerCollection.IsVisible = true;
        addCustomerPage.IsVisible = false;

        customerCollection.ItemsSource = CustomerManager.customers;
    }

	private void OnBanButtonClicked (object sender, EventArgs e)
	{
        var button = (Button)sender;
        var customer = (Customer)button.BindingContext;

		if (customer.IsBanned == 0)
		{
			customer.IsBanned = 1;
		}
		else
		{
            customer.IsBanned = 0;
        }
		CustomerManager.UpdateCustomer(customer);

        customerCollection.ItemsSource = CustomerManager.customers;
    }

    private void OnUpdateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(firstNameEntryUpdate.Text) ||
            string.IsNullOrEmpty(lastNameEntryUpdate.Text) ||
            string.IsNullOrEmpty(contactPhoneEntryUpdate.Text) ||
            string.IsNullOrEmpty(emailEntryUpdate.Text))
        {
            DisplayAlert("All fields must be filled", "The customer information has not been completely filled out, please, fill all the information.", "OK");
            return;
        }

        Customer updatedCustomer = new Customer(updateCustomer.CustomerId, lastNameEntryUpdate.Text, firstNameEntryUpdate.Text, contactPhoneEntryUpdate.Text, emailEntryUpdate.Text, updateCustomer.IsBanned);
        CustomerManager.UpdateCustomer(updatedCustomer);

        MainButton.IsVisible = true;
        customerCollection.IsVisible = true;
        updateCustomerPage.IsVisible = false;

        customerCollection.ItemsSource = CustomerManager.customers;
    }


}