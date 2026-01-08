using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Contracts.Orders;
using ProjectName.Application.Execution;
using ProjectName.Api.Extensions;
using ProjectName.Application.UsesCases.CreateOrder;

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
    public async Task<IActionResult> Create([FromBody] CreateOrderApiRequest apiRequest)
    {
        var request = new CreateOrderRequest(apiRequest.TotalAmount);
        var result = await _executor.ExecuteAsync<CreateOrderRequest, CreateOrderResponse> (request);

        if (!result.IsSuccess)
            return BadRequest(result.ToApiResponse());

        return Created(string.Empty, result.ToApiResponse());
    }

}                                                                                                                   
