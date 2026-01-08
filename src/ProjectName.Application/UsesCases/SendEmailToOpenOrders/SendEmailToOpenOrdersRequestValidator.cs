using FluentValidation;
using ProjectName.Application.UsesCases.SendEmailToOpenOrders;

public class SendEmailToOpenOrdersRequestValidator
    : AbstractValidator<SendEmailToOpenOrdersRequest>
{
    public SendEmailToOpenOrdersRequestValidator()
    {

    }
}
