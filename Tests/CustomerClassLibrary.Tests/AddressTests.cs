using Xunit;

namespace CustomerClassLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = new Address("", "", AddressTypes.Shipping, "Ottawa", "A0N", "", "Canada");
            Assert.Equal("", address.Line);
            Assert.Equal("", address.Line2);
            Assert.Equal(AddressTypes.Shipping, address.AddressType);
            Assert.Equal("Ottawa", address.City);
            Assert.Equal("A0N", address.PostalCode);
            Assert.Equal("", address.State);
            Assert.Equal("Canada", address.Country);
        }
    }
}
