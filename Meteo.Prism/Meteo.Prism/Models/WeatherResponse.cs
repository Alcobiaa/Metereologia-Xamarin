using System.Collections.Generic;

namespace Meteo.Prism.Models
{
    public class WeatherResponse
    {
        public Coord Coord { get; set; }

        public List<Weather> Weather { get; set; }

        public string Base { get; set; }

        public Main Main { get; set; }

        public string Visibility { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public int Dt { get; set; }

        public Sys Sys { get; set; }

        public int TimeZone { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }
    }
}
