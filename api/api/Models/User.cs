using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            InverseIdIndicatedNavigation = new HashSet<User>();
            Notifications = new HashSet<Notification>();
            QuestionUsers = new HashSet<QuestionUser>();
        }

        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] Photo { get; set; }
        public string Nickname { get; set; }
        public string FavoriteTeam { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime? Birthday { get; set; }
        public int? IdIndicated { get; set; }
        public DateTime? SignupDate { get; set; }
        public DateTime InviteDate { get; set; }
        public bool? ReceiveNotification { get; set; }

        public virtual User IdIndicatedNavigation { get; set; }
        public virtual ICollection<User> InverseIdIndicatedNavigation { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<QuestionUser> QuestionUsers { get; set; }
    }
}
