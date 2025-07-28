
using FluentValidation;
using MotoService.Application.ServiceRecords.DTOs;

namespace MotoService.Application.ServiceRecords.Validators;

public class CreateServiceRecordRequestValidator : AbstractValidator<CreateServiceRecordRequest>
{
    public CreateServiceRecordRequestValidator()
    {
        RuleFor(x => x.MotorcycleId).NotEmpty();
        RuleFor(x => x.ServiceDate).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.TotalCost).GreaterThan(0);
    }
}
