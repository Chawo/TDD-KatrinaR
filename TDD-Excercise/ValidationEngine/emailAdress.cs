using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValidationEngine
{
    public class emailAdress
    {
        private string email { get; set; }
        private bool result { get; set; }

        public string _email
        {
            get { return email; }
            set { email = value; }
        }
         
        public emailAdress(string emailIn)
        {
            _email = emailIn;
        }

        public bool ValidAdress()
        {
            return Regex.IsMatch(email,
              @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}
