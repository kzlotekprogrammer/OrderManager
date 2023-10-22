using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManager.API.Controllers.v1.Extensions;
using OrderManager.API.Controllers.v1.Models;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.API.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IMediator _mediator;

    public OrderController(ILogger<OrderController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        CommandResult<Guid> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Data);
    }

    [HttpPost]
    [Route("AddItem")]
    public async Task<IActionResult> AddOrderItem([FromBody] AddOrderItemRequest request)
    {
        CommandResult<Guid> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Data);
    }
}