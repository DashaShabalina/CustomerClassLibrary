using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.Tests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToRightRequiredParam()
        {
            var actualErrors = CustomerValidator.CheckCustomer(new Customer("Dasha", "", "+79831508080", "dasha@gmail.com", null, double.NaN, null));
            var expectedErrors = new List<string>()
            {
                "Error : Last Name as text - required",
                "Error : Addresses List - required",
                "Error : Notes - required"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }

        [Fact]
        public void ShouldBeAbleToRightLengths()
        {
            var customer = new Customer("string length too long. string length too long. string length too long.",
                "string length too long. string length too long. string length too long.",
                "+79831508080",
                "dasha@gmail.com",
                new List<Address> { new Address() },
                100,
                new List<string> { new string("") });

            var actualErrors = CustomerValidator.CheckCustomer(customer);
            var expectedErrors = new List<string>()
            {
                "Error : Maximum length of the First Name is 50 characters",
                "Error : Maximum length of the Last Name is 50 characters"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }

        [Fact]
        public void ShouldBeAbleToRightPhone()
        {
            var actualErrors = CustomerValidator.CheckCustomer(new Customer("", "Shabalina", "+7983150808018888", "dasha@gmail.com", null, 100, null));
            var expectedErrors = new List<string>()
            {
                "Error : Addresses List - required",
                "Error : Notes - required",
                "Error : The Phone Number must be in E.164 format"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }

        [Fact]
        public void ShouldBeAbleToRightEmail()
        {
            var actualErrors = CustomerValidator.CheckCustomer(new Customer("", "Shabalina", "+79831508080", "da@sha@gmail.com", null, 100, null));
            var expectedErrors = new List<string>()
            {
                "Error : Addresses List - required",
                "Error : Notes - required",
                "Error : Wrong Email address"
            };

            Assert.Equal(expectedErrors, actualErrors);
        }

    }
}