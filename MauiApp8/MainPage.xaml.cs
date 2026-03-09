namespace MauiApp8
{
    public partial class MainPage : ContentPage
    {
        double basePrice = 0;
        double doughExtra = 0;
        int quantity = 1;

        public MainPage()
        {
            InitializeComponent();
            UpdatePrice();
        }

        private void OnOptionChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.IsChecked)
            {
                if (rb.GroupName == "Size")
                    basePrice = Convert.ToDouble(rb.Value);
                else if (rb.GroupName == "Dough")
                    doughExtra = Convert.ToDouble(rb.Value);
            }

            if (sender is Stepper stepper)
            {
                quantity = (int)stepper.Value;
                QuantityLabel.Text = $"{quantity} szt.";
            }

            UpdatePrice();
        }

        private void UpdatePrice()
        {
            double total = (basePrice + doughExtra) * quantity;
            TotalPriceLabel.Text = $"{total:0.00} zł";
        }

    }
}
