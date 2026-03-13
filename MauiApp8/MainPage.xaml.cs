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
*******************************************************************
nazwa funkcji: OnOptionChanged
opis funkcji: Funkcja sprawdza, jaką wybrano wielkość i grubość pizzy oraz ilość sztuk ustawionych w Stepperze. Na podstawie wartości RadioButtonów pobiera cenę i aktualizuje ilość. Na koniec wywołuje funkcję UpdatePrice().
parametry: sender – obiekt wywołujący zdarzenie, e – argumenty zdarzenia
zwracany typ i opis: brak(void) – funkcja wyswietla ilość sztuk pizzy.
autor: Julia Nowakowska
*******************************************************************

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
*******************************************************************
nazwa funkcji: UpdatePrice
opis funkcji: Funkcja oblicza cenę końcową pizzy na podstawie wybranej wielkości, rodzaju ciasta oraz ilości sztuk. Następnie wyświetla wynik w etykiecie TotalPriceLabel.
parametry: brak
zwracany typ i opis: brak (void) – funkcja wyświetla cenę końcową.
autor: Julia Nowakowska
*******************************************************************
        private void UpdatePrice()
        {
            double total = (basePrice + doughExtra) * quantity;
            TotalPriceLabel.Text = $"{total:0.00} zł";
        }

    }
}
