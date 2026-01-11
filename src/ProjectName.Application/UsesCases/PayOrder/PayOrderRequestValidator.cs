using FluentValidation;


namespace ProjectName.Application.UsesCases.PayOrder;
public class PayOrderRequestValidator : AbstractValidator<PayOrderRequest>
{
    public PayOrderRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("OrderId is required");
    }
}
