using FluentValidation;
using ProjectName.Application.UseCases.ProcessOrderPaid;


public class ProcessOrderPaidRequestValidator : AbstractValidator<ProcessOrderPaidRequest>
{
    public ProcessOrderPaidRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("OrderId is required");
    }
}