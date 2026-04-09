using FluentValidation;
using ProjectName.Application.UseCases.CreateOrder;

public class CreateOrderRequestValidator
    : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.TotalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("TotalAmount must be zero or greater");
    }
}
