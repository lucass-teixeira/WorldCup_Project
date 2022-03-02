using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Competition
    {
        public Competition()
        {
            Games = new HashSet<Game>();
        }

        public int IdCompetition { get; set; }
        public int? Year { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
