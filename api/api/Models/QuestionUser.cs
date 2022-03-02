using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class QuestionUser
    {
        public int IdQuestionUser { get; set; }
        public int IdQuestion { get; set; }
        public int? IdUser { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
