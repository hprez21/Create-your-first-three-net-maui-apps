namespace BMIDemo
{
    public partial class MainPage : ContentPage
    {
        const double UnderweightThreshold = 18.5;
        const double NormalWeightThreshold = 24.9;
        const double OverweightThreshold = 29.9;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var weight = double.Parse(Weight.Text);
            var height = double.Parse(Height.Text) / 100;

            var imc = weight / (height * height);

            BMI.Text = imc.ToString("F2");

            string result = GetBmiResultMessage(imc);
            DisplayAlert("Result", result, "Ok");
        }

        private string GetBmiResultMessage(double imc)
        {
            if (imc < UnderweightThreshold)
            {
                return "You have low weight";
            }
            else if (imc <= NormalWeightThreshold)
            {
                return "You weight is normal";
            }
            else if (imc <= OverweightThreshold)
            {
                return "You are overweight";
            }
            else
            {
                return "You have obesity, take care of yourself!";
            }
        }
    }
}