
using FluentValidation;
using MotoService.Application.ServiceRecords.DTOs;

namespace MotoService.Application.ServiceRecords.Validators;

public class UpdateServiceRecordRequestValidator : AbstractValidator<UpdateServiceRecordRequest>
{
    public UpdateServiceRecordRequestValidator()
    {
        RuleFor(x => x.ServiceDate).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.TotalCost).GreaterThan(0);
    }
}
