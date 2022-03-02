using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class VwJogo
    {
        public string Data { get; set; }
        public string Hora { get; set; }
        public int IdJogo { get; set; }
        public int? IdCompeticao { get; set; }
        public string Time1 { get; set; }
        public int? Placar1 { get; set; }
        public string X { get; set; }
        public int? Placar2 { get; set; }
        public string Time2 { get; set; }
    }
}
