
using FluentValidation;
using MotoService.Application.Customers.DTOs;

namespace MotoService.Application.Customers.Validators;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
    }
}
