using System.Collections.Generic;

namespace CustomerClassLibrary
{
    public class AddressValidator
    {
        static public List<string> CheckAddress(Address address)
        {
            var errorList = new List<string>();
            if (string.IsNullOrEmpty(address.Line)) errorList.Add("Error : Address Line as text - required");
            if (address.Line.Length > 100) errorList.Add("Error : Maximum length of the address line is 100 characters");
            if (address.Line2.Length > 100) errorList.Add("Error : Maximum length of the address line2 is 100 characters");
            if (string.IsNullOrEmpty(address.City)) errorList.Add("Error : City as text - required");
            if (address.City.Length > 50) errorList.Add("Error : Maximum length of the name City is 50 characters");
            if (string.IsNullOrEmpty(address.PostalCode)) errorList.Add("Error : PostalCode as text - required");
            if (address.PostalCode.Length > 6) errorList.Add("Error : Maximum length of the Postal Code is 6 characters");
            if (string.IsNullOrEmpty(address.State)) errorList.Add("Error : State as text - required");
            if (address.State.Length > 20) errorList.Add("Error : Maximum length of the State is 20 characters");
            if (string.IsNullOrEmpty(address.Country)) errorList.Add("Error : Country as text - required");
            else if (address.Country != "United States" && address.Country != "Canada")
                errorList.Add("Error : Country should be Unated States or Canada");
            return errorList;
        }
    }
}
