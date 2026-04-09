using FluentValidation;


namespace ProjectName.Application.UseCases.PayOrder;
public class PayOrderRequestValidator : AbstractValidator<PayOrderRequest>
{
    public PayOrderRequestValidator()
    {
    }
}
