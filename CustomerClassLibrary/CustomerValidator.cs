using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public class CustomerValidator
    {
        static public List<string> CheckCustomer(Customer customer)
        {
            var errorList = new List<string>();
            if (customer.FirstName.Length > 50) errorList.Add("Error : Maximum length of the First Name is 50 characters");
            if (string.IsNullOrEmpty(customer.LastName)) errorList.Add("Error : Last Name as text - required");
            if (customer.LastName.Length > 50) errorList.Add("Error : Maximum length of the Last Name is 50 characters");
            if (customer.AddressesList == null) errorList.Add("Error : Addresses List - required");
            if (customer.Notes == null) errorList.Add("Error : Notes - required");
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$")) errorList.Add("Error : The Phone Number must be in E.164 format");
            if (!Regex.IsMatch(customer.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) errorList.Add("Error : Wrong Email address");
            return errorList;
        }
    }
}
