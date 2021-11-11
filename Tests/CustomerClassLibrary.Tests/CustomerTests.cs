using Xunit;

namespace CustomerClassLibrary.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreatePerson()
        {
            var customer = new Customer("Dasha", "Shabalina", "+74951234567", "dasha@gmail.com",null,100,null);
            Assert.Equal("Dasha", customer.FirstName);
            Assert.Equal("Shabalina", customer.LastName);
            Assert.Equal("+74951234567", customer.PhoneNumber);
            Assert.Equal("dasha@gmail.com", customer.Email);
            Assert.Equal(100, customer.TotalPurchasesAmoun);
            Assert.Null(customer.AddressesList);
            Assert.Null(customer.Notes);
        }
    }
}
