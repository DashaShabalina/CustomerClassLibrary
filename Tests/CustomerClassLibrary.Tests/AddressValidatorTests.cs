using System.Collections.Generic;
using Xunit;
namespace CustomerClassLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToRightRequiredParam()
        {
            var actualErrors = new Address("", "line 2", AddressTypes.Billing, "", "", "", "");
            var validator = new AddressValidator();
            var expectedErrors = new List<string>()
            {
                "Error : Address Line as text - required",
                "Error : City as text - required",
                "Error : PostalCode as text - required",
                "Error : State as text - required",
                "Error : Country as text - required"
            };

            Assert.Equal(expectedErrors, validator.RunAddressValidator(actualErrors));
        }

        [Fact]
        public void ShouldBeAbleToRightCountry()
        {
            var actualErrors = new Address("1", "line 2", AddressTypes.Billing, "1", "1", "1", "Russia");
            var expectedErrors = new List<string>()
            {
                "Error : Country should be Unated States or Canada"
            };
            var validator = new AddressValidator();
            Assert.Equal(expectedErrors, validator.RunAddressValidator(actualErrors));
        }
    }
}
