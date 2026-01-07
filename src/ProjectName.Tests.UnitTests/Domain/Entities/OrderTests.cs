using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;

namespace ProjectName.Tests.UnitTests.Domain.Entities;
public class OrderTests
{
    [Fact]
    public void Pay_ShouldChangeStatusToPaid()
    {
        var order = new Order(OrderStatus.Open, totalAmount: 100);
        order.Pay();
        Assert.Equal(OrderStatus.Paid, order.Status);
    }

    [Fact]
    public void Pay_ShouldThrow_WhenOrderIsCanceled()
    {
        var order = new Order(OrderStatus.Canceled, totalAmount: 100);
        Assert.Throws<InvalidOperationException>(() => order.Pay());
    }
}