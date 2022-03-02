using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionUsers = new HashSet<QuestionUser>();
        }

        public int IdQuestion { get; set; }
        public string Question1 { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }

        public virtual ICollection<QuestionUser> QuestionUsers { get; set; }
    }
}
