using System.Collections.Generic;

namespace CustomerClassLibrary
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName, string phoneNumber, string email,
            List<Address> addressesList, double totalPurchasesAmoun, List<string> notes) : base(firstName, lastName)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            TotalPurchasesAmoun = totalPurchasesAmoun;
            AddressesList = addressesList;
            Notes = notes;
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double TotalPurchasesAmoun { get; set; }
        public List<Address> AddressesList { get; set; }
        public List<string> Notes { get; set; }
    }
}
