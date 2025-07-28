
using FluentValidation;
using MotoService.Application.Motorcycles.DTOs;

namespace MotoService.Application.Motorcycles.Validators;

public class CreateMotorcycleRequestValidator : AbstractValidator<CreateMotorcycleRequest>
{
    public CreateMotorcycleRequestValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Model).NotEmpty().MaximumLength(50);
        RuleFor(x => x.PlateNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year);
    }
}
