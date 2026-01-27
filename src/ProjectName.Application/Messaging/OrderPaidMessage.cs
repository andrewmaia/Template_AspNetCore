namespace ProjectName.Application.Messaging;

public sealed class OrderPaidMessage
{
    public Guid OrderId { get; init; }
    public DateTime CreatedAt { get; init; }
}