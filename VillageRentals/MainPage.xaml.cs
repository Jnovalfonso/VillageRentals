namespace VillageRentals
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnInventoryClicked (object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(InventoryMenu));
        }

        private void OnCustomerClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(CustomerMenu));
        }

        private void OnRentalClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(RentalMenu));
        }

    }

}
