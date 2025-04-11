namespace TipCalculator
{
    public partial class TipGrid : ContentPage
    {
        bool arrendondaPraCima;
        bool arrendondaPraBaixo;
        public TipGrid()
        {
            InitializeComponent();
            Grid_tipPercentSlider.ValueChanged += (s, e) => CalculateTip();
        }

        private void Grid_OnNormalTip(object sender, EventArgs e)
        {
            Grid_tipPercentSlider.Value = 15;
        }


        private void CalculateTip()
        {
            double valor = Convert.ToDouble(Grid_billInput.Text);
            double percentualDaGorjeta = Grid_tipPercentSlider.Value;
            double gorjeta = valor * (percentualDaGorjeta / 100);
            if (arrendondaPraCima)
            {
                gorjeta = Math.Ceiling(gorjeta);
            }
            if (arrendondaPraBaixo)
            {
                gorjeta = Math.Floor(gorjeta);
            }
            double total = valor + gorjeta;
            //Currency
            Grid_tipOutput.Text = gorjeta.ToString("C");
            Grid_totalOutput.Text = total.ToString("C");
        }


        private void Grid_OnGenerousTip(object sender, EventArgs e)
        {

        }

        private void Grid_roundUp_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = true;
            arrendondaPraBaixo = false;
        }

        private void Grid_roundDown_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = false;
            arrendondaPraBaixo = true;
        }
    }
}