
using FluentValidation;
using MotoService.Application.Motorcycles.DTOs;

namespace MotoService.Application.Motorcycles.Validators;

public class UpdateMotorcycleRequestValidator : AbstractValidator<UpdateMotorcycleRequest>
{
    public UpdateMotorcycleRequestValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Model).NotEmpty().MaximumLength(50);
        RuleFor(x => x.PlateNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year);
    }
}
