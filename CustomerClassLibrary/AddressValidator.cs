using System.Collections.Generic;
using FluentValidation;

namespace CustomerClassLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line).NotEmpty().WithMessage("Error : Address Line as text - required");
            RuleFor(address => address.Line).MaximumLength(100).WithMessage("Error: Maximum length of the address line is 100 characters");
            RuleFor(address => address.Line2).MaximumLength(100).WithMessage("Error : Maximum length of the address line2 is 100 characters");
            RuleFor(address => address.City).NotEmpty().WithMessage("Error : City as text - required");
            RuleFor(address => address.City).MaximumLength(50).WithMessage("Error : Maximum length of the name City is 50 characters");
            RuleFor(address => address.PostalCode).NotEmpty().WithMessage("Error : PostalCode as text - required");
            RuleFor(address => address.PostalCode).MaximumLength(6).WithMessage("Error : Maximum length of the Postal Code is 6 characters");
            RuleFor(address => address.State).NotEmpty().WithMessage("Error : State as text - required");
            RuleFor(address => address.State).MaximumLength(20).WithMessage("Error : Maximum length of the State is 20 characters");
            RuleFor(address => address.Country).NotEmpty().WithMessage("Error : Country as text - required");
            var conditions = new List<string>() { "Canada", "Unated States" };
            RuleFor(x => x.Country)
              .Must(x => conditions.Contains(x.ToLower())).When(address => address.Country != null && address.Country != string.Empty)
              .WithMessage("Error : Country should be Unated States or Canada");
        }

        public List<string> RunAddressValidator(Address address)
        {
            var errorList = new List<string>();
            var validator = new AddressValidator();
            var results = validator.Validate(address);
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
