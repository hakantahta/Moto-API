
using FluentValidation;
using MotoService.Application.Customers.DTOs;

namespace MotoService.Application.Customers.Validators;

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
    }
}
