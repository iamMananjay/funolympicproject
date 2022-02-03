using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            MailServer = "smtp.gmail.com";
            MailPort = 465;
            SenderName = "EmployeeManagement";
            Sender = "Mananjaysth11@gmail.com";
            Password = "blackmandu1@";
        }
        public String MailServer { get; set; }
        public int MailPort { get; set; }
        public String SenderName { get; set; }
        public String Sender { get; set; }
        public String Password { get; set; }
    }
}
