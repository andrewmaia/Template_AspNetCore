using FluentValidation;
using ProjectName.Application.UsesCases.CreateOrder;

public class CreateOrderRequestValidator
    : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.TotalAmount)
            .GreaterThan(0)
            .WithMessage("TotalAmount must be greater than zero");
    }
}
