namespace PomodoroApp
{
    public partial class MainPage : ContentPage
    {
        TimeSpan _remainingTime;
        IDispatcherTimer timer;

        public MainPage()
        {
            InitializeComponent();

            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += async (s, e) => await TimerTickAsync();
        }
        private async Task TimerTickAsync()
        {
            _remainingTime -= TimeSpan.FromSeconds(1);
            
            lblValue.Text = _remainingTime.ToString(@"m\:ss");

            GaugeNeedle.Value = _remainingTime.TotalMinutes;
        }

            private void btnStart_Clicked(object sender, EventArgs e)
        {
            StartPomodoroTimer();
        }

        private void StartPomodoroTimer()
        {
            _remainingTime = TimeSpan.FromMinutes(GaugeNeedle.Value);

            timer.Start();
        }

    }
}