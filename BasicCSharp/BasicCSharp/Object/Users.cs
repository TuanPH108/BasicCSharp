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

        public Users (Guid ID, string Name, string Birthday, string Email, string Contact)
        {
            User_ID = ID;
            User_Name = Name;
            User_Birthday = Birthday;
            User_Email = Email;
            User_Contact = Contact;
        }
        public Users() { }
    }
}
