namespace CustomerClassLibrary
{
    public enum AddressTypes
    {
        Shipping,
        Billing
    }
    public class Address
    {
        public Address() { }
        public Address(string line, string line2, AddressTypes addressType, string city,
            string postalCode, string state, string country)
        {
            Line = line;
            Line2 = line2;
            AddressType = addressType;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
        public string Line { get; set; }
        public string Line2 { get; set; }
        public AddressTypes AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
