using System;
using System.Collections.Generic;
using System.Text;

namespace Meteo.Prism.Models
{
    public class Sys
    {
        public string Type { get; set; }

        public int Id { get; set; }

        public string Country { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }
    }
}
