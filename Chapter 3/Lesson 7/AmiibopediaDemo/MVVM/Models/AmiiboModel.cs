using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmiibopediaDemo.MVVM.Models
{

    public class AmiiboModel
    {
        [JsonPropertyName("amiibo")]
        public List<Amiibo> Amiibos { get; set; }
    }

    public class Amiibo
    {
        public string amiiboSeries { get; set; }
        public string character { get; set; }
        public string gameSeries { get; set; }
        public string head { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public Release release { get; set; }
        public string tail { get; set; }
        public string type { get; set; }
    }

    public class Release
    {
        public string au { get; set; }
        public string eu { get; set; }
        public string jp { get; set; }
        public string na { get; set; }
    }

}
