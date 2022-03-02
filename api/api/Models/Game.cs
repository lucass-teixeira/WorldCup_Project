using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Game
    {
        public int IdGame { get; set; }
        public DateTime? Date { get; set; }
        public int? IdCompetition { get; set; }
        public int? Team1 { get; set; }
        public int? Score1 { get; set; }
        public int? Penalty1 { get; set; }
        public int? Team2 { get; set; }
        public int? Score2 { get; set; }
        public int? Penalty2 { get; set; }

        public virtual Competition IdCompetitionNavigation { get; set; }
        public virtual Team Team1Navigation { get; set; }
        public virtual Team Team2Navigation { get; set; }
    }
}
