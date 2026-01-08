using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Contracts;
using ProjectName.Api.Contracts.Orders;
using ProjectName.Api.Extensions;
using ProjectName.Application.Execution;
using ProjectName.Application.UsesCases.CreateOrder;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectName.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly RequestExecutor _executor;

    public OrdersController(RequestExecutor executor)
    {
        _executor = executor;
    }

    [HttpPost]
    [SwaggerOperation(
    Summary = "Create a new order",
    Description = "Creates an order and returns a generic response wrapper.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Order created successfully",typeof(ApiResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data", typeof(ApiResponse))]
    public async Task<IActionResult> Create([FromBody] CreateOrderApiRequest apiRequest)
    {
        var request = new CreateOrderRequest(apiRequest.TotalAmount);
        var result = await _executor.ExecuteAsync<CreateOrderRequest, CreateOrderResponse> (request);

        if (!result.IsSuccess)
            return BadRequest(result.ToApiResponse());

        return Created(string.Empty, result.ToApiResponse());
    }

}                                                                                                                   
