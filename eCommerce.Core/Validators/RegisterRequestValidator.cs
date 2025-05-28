using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    

    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
        
        //Name
        RuleFor(temp => temp.PersonName)
            .NotEmpty().WithMessage("PersonName is required");
        
        // Gender
        RuleFor(temp => temp.Gender)
            .IsInEnum().WithMessage("Gender is invalid");

        //Password
        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}