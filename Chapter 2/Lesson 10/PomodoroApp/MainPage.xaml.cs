using Plugin.Maui.Audio;

namespace PomodoroApp
{
    public partial class MainPage : ContentPage
    {
        TimeSpan _remainingTime;
        IDispatcherTimer timer;
        bool isPomodoroRunning = false;

        static readonly Color StartBackgroundColor = Color.FromArgb("FFC914");
        static readonly Color StopBackgroundColor = Color.FromArgb("FF0000");
        static readonly Color StartTextColor = Color.FromArgb("FFFF");
        static readonly Color StopTextColor = Color.FromArgb("FFFF");

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

                var audioPlayer = AudioManager.Current
                    .CreatePlayer(await FileSystem.OpenAppPackageFileAsync("alarm.wav"));
                audioPlayer.Play();
                audioPlayer.PlaybackEnded += (s, e) => audioPlayer.Dispose();
            }
        }
        private void StopPomodoro()
        {
            isPomodoroRunning = false;
            timer.Stop();

            btnStart.BackgroundColor = StartBackgroundColor;
            btnStart.Text = "Start";
            btnStart.TextColor = StartTextColor;

            GaugeNeedle.IsInteractive = true;
        }


        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if (!isPomodoroRunning)
            {
                StartPomodoroTimer();
            }
            else
            {
                StopPomodoro();
            }
        }

        private void StartPomodoroTimer()
        {
            isPomodoroRunning = true;

            _remainingTime = TimeSpan.FromMinutes(GaugeNeedle.Value);

            timer.Start();

            btnStart.BackgroundColor = StopBackgroundColor;
            btnStart.Text = "Stop";
            btnStart.TextColor = StopTextColor;


            GaugeNeedle.IsInteractive = false;
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