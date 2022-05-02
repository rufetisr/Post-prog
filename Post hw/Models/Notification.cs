using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;

namespace Post_hw
{
    class Notification
    {
        public Notification(int id, string text, DateTime dateTime, User fromUser)
        {
            Id = id;
            Text = text;
            DateTime = dateTime;
            FromUser = fromUser;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public User FromUser { get; set; }


    }
}
