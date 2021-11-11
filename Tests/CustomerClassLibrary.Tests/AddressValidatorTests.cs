using System.Collections.Generic;
using Xunit;
namespace CustomerClassLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToRightRequiredParam()
        {
            var actualErrors = AddressValidator.CheckAddress(new Address("", "line 2", AddressTypes.Billing, "", "", "", ""));
            var expectedErrors = new List<string>()
            {
                "Error : Address Line as text - required",
                "Error : City as text - required",
                "Error : PostalCode as text - required",
                "Error : State as text - required",
                "Error : Country as text - required"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }

        [Fact]
        public void ShouldBeAbleToRightLengths()
        {
            var address = new Address("string length too long. string length too long. string length too long. string length too long. string length too long.",
                "string length too long. string length too long. string length too long. string length too long. string length too long.",
                AddressTypes.Billing,
                "string length too long. string length too long. string length too long.",
                "string length too long.",
                "string length too long.",
                "Canada");
            var actualErrors = AddressValidator.CheckAddress(address);
            var expectedErrors = new List<string>()
            {
                "Error : Maximum length of the address line is 100 characters",
                "Error : Maximum length of the address line2 is 100 characters",
                "Error : Maximum length of the name City is 50 characters",
                "Error : Maximum length of the Postal Code is 6 characters",
                "Error : Maximum length of the State is 20 characters"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }
        [Fact]
        public void ShouldBeAbleToRightCountry()
        {
            var actualErrors = AddressValidator.CheckAddress(new Address("1", "line 2", AddressTypes.Billing, "1", "1", "1", "Russia"));
            var expectedErrors = new List<string>()
            {
                "Error : Country should be Unated States or Canada"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }
    }
}
