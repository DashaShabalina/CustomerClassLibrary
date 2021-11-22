using System.Collections.Generic;
using FluentValidation;

namespace CustomerClassLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(50).WithMessage("Error : Maximum length of the First Name is 50 characters");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Error : Last Name as text - required");
            RuleFor(customer => customer.LastName).MaximumLength(50).WithMessage("Error : Maximum length of the Last Name is 50 characters");
            RuleFor(customer => customer.AddressesList).NotNull().WithMessage("Error : Addresses List - required");
            RuleFor(customer => customer.Notes).NotNull().WithMessage("Error : Notes - required");
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Error : The Phone Number must be in E.164 format");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Error : Wrong Email address");
        }

        public List<string> RunCustomerValidator(Customer customer)
        {
            var errorList = new List<string>();
            var validator = new CustomerValidator();
            var results = validator.Validate(customer);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errorList.Add(error.ErrorMessage);
                }
            }
            return errorList;
        }
    }
}
