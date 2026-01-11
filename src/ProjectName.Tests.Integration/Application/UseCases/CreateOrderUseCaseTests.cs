
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectName.Application.UsesCases.CreateOrder;
using ProjectName.Domain.Enums;
using ProjectName.Domain.Services;
using ProjectName.Infrastructure.PostgreSQL;
using ProjectName.Infrastructure.PostgreSQL.Context;
using ProjectName.Infrastructure.PostgreSQL.Repositories;
using ProjectName.Tests.Integration.Application.Fixtures;
using ProjectName.Tests.Integration.Application.Repositories;

namespace ProjectName.Tests.Integration;

public class CreateOrderUseCaseTests
{
    [Fact]
    public async Task Should_CreateOrderSuccessfull_InMemory()
    {
        var options = new DbContextOptionsBuilder<ProjectNameDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new ProjectNameDbContext(options);

        var orderRepository = new OrderRepositoryInMemory(context);
        var unitOfWork = new UnitOfWorkInMemory(context);
        var orderService = new OrderDomainService(); 

        var useCase = new CreateOrderUseCase(orderRepository, unitOfWork, orderService);

        var request = new CreateOrderRequest(totalAmount: 100m);

        // Act
        var response = await useCase.ExecuteAsync(request);

        // Assert
        var savedOrder =await  orderRepository.GetByIdAsync(response.OrderId!.Value);

        Assert.NotNull(savedOrder);
        Assert.Equal(OrderStatus.Open, savedOrder!.Status);
    }

    [Fact]
    public async Task Should_CreateOrderSuccessfull_RealDb()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("TestDb");

        //DbContext real
        var options = new DbContextOptionsBuilder<ProjectNameDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        await using var context = new ProjectNameDbContext(options);

        var orderRepository = new OrderRepository(context);
        var unitOfWork = new UnitOfWork(context);
        var orderService = new OrderDomainService();

        var useCase = new CreateOrderUseCase(orderRepository, unitOfWork, orderService);

        var request = new CreateOrderRequest(totalAmount: 100m);

        // Act
        var response = await useCase.ExecuteAsync(request);

        // Assert
        var savedOrder = await  orderRepository.GetByIdAsync(response.OrderId!.Value);

        Assert.NotNull(savedOrder);
        Assert.Equal(OrderStatus.Open, savedOrder!.Status);
    }
}

