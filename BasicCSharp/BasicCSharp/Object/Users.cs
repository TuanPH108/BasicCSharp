using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCSharp.Object
{
    public class Users
    {
        public Guid User_ID { get; set; }
        public string User_Name { get; set;} = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Birthday {  get; set; } = string.Empty;
        public string User_Contact {  get; set; } = string.Empty;

        public Users (string Name, string Birthday, string Email, string Contact)
        {
            this.User_Name = Name;
            this.User_Birthday = Birthday;
            this.User_Email = Email;
            this.User_Contact = Contact;
        }
        public Users()
        {

        }
    }
}
