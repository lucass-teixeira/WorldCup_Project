using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Team
    {
        public Team()
        {
            GameTeam1Navigations = new HashSet<Game>();
            GameTeam2Navigations = new HashSet<Game>();
        }

        public int IdTeam { get; set; }
        public string Name { get; set; }
        public byte[] Flag { get; set; }

        public virtual ICollection<Game> GameTeam1Navigations { get; set; }
        public virtual ICollection<Game> GameTeam2Navigations { get; set; }
    }
}
