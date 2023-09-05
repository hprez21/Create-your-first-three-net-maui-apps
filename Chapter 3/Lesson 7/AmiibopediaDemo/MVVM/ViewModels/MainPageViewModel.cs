using AmiibopediaDemo.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AmiibopediaDemo.MVVM.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Amiibo> amiibos;

        private List<Amiibo> allAmiibos;

        HttpClient client;

        string allAmiibosEndpoint = "https://amiiboapi.com/api/amiibo/";


        public MainPageViewModel()
        {
            client = new HttpClient();
        }

        public async Task FillData()
        {
            client.BaseAddress = new Uri(allAmiibosEndpoint);
            var response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var amiiboModel = JsonSerializer.Deserialize<AmiiboModel>(json);
                allAmiibos = amiiboModel.Amiibos;
                Amiibos = allAmiibos;
            }
        }

        public void FilterList(string filter)
        {
            Amiibos = allAmiibos.Where(x => x.name.ToLower().Contains(filter.ToLower())).ToList();
        }

    }
}
