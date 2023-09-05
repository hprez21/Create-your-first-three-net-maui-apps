namespace PomodoroApp
{
    public partial class MainPage : ContentPage
    {
        TimeSpan _remainingTime;
        IDispatcherTimer timer;
        bool isPomodoroRunning = false;

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

            if (_remainingTime.TotalSeconds <= 0)
            {
                StopPomodoro();
            }
        }
        private void StopPomodoro()
        {
            isPomodoroRunning = false;
            timer.Stop();
        }


        private void btnStart_Clicked(object sender, EventArgs e)
        {
            StartPomodoroTimer();
        }

        private void StartPomodoroTimer()
        {
            isPomodoroRunning = true;

            _remainingTime = TimeSpan.FromMinutes(GaugeNeedle.Value);

            timer.Start();
        }

        private void GaugeNeedle_ValueChanged(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
        {
            if (!isPomodoroRunning)
            {
                lblValue.Text = e.Value.ToString("00") + ":00";
            }
        }
    }
}