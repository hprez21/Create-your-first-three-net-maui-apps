using AmiibopediaDemo.MVVM.ViewModels;

namespace AmiibopediaDemo
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.FillData();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FilterList(e.NewTextValue);
        }
    }
}