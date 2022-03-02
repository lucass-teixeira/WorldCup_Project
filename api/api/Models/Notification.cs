using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public DateTime DateHour { get; set; }
        public string NotificationMessage { get; set; }
        public int IdUser { get; set; }
        public string Status { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
