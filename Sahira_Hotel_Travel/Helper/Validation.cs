using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sahira_Hotel_Travel.Helper
{
    public class Validation
    {
        public bool isValidPassword(string password)
        {
            bool valid = false;

            if (password.Any(x => char.IsDigit(x)) && password.Any(x => char.IsLetter(x)))
            {
                valid = true;
            }

            return valid;
        }

        public bool isPasswordMatch(string password, string retype)
        {
            bool match = false;

            if (password.Equals(retype))
            {
                match = true;
            }

            return match;
        }

        public bool isNameLengthGreaterEqualThan3(string nama)
        {
            bool yes = false;
            if (nama.Length >= 3) yes = true;
            return yes;
        }

        public string generateCustomerCode(string code)
        {
            Random rand = new Random();
            for (int i = 0; i < 4; i++ )
                code += "" + rand.Next(0, 9);
            return code;
        }

        public bool isEmailValid(string email)
        {
            bool valid = false;

            try
            {
                string address = new MailAddress(email).Address;
                if (!address.EndsWith("."))
                {
                    if(!address.Contains("..") || !address.Contains("@.") || 
                        !address.Contains(".@") || !address.Contains("._.") || 
                        !address.Contains("._") || !address.Contains("_.")) {
                            valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                valid = false;
            }

            return valid;
        }

        public bool isAddressLenghtGreaterEqualThan6(string address)
        {
            bool yes = false;
            if (address.Length >= 6) yes = true;
            return yes;
        }

        public bool isPasswordLenghtGreaterEqualThan6(string password)
        {
            bool yes = false;
            if (password.Length >= 6) yes = true;
            return yes;
        }

        public bool isPhoneLenghtValid(string phone)
        {
            bool valid = false;
            if (phone.Length >= 10 && phone.Length <= 13) valid = true;
            return valid;
        }

        public bool isPhoneValid(string phone)
        {
            bool valid = false;
            if (!phone.Any(x => char.IsLetter(x)) && !phone.Any(x=>char.IsSymbol(x))) valid = true;
            return valid;
        }

        public bool isDurationValid(string duration) {
            bool valid = false;
            if (isPhoneValid(duration))
            {
                if (int.Parse(duration) >= 3 && int.Parse(duration) <= 5) valid = true;
            }
            return valid;
        }
    }
}
