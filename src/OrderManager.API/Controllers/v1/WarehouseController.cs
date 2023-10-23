using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManager.API.Controllers.v1.Extensions;
using OrderManager.API.Controllers.v1.Models;
using OrderManager.BuildingBlocks;

namespace OrderManager.API.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly ILogger<WarehouseController> _logger;
    private readonly IMediator _mediator;

    public WarehouseController(ILogger<WarehouseController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    [Route("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        CommandResult<Guid> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Data);
    }

    [HttpPost]
    [Route("UpdatePrice")]
    public async Task<IActionResult> UpdatePrice([FromBody] UpdatePriceRequest request)
    {
        CommandResult<Unit> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok();
    }

    [HttpPost]
    [Route("UpdateAmount")]
    public async Task<IActionResult> UpdateAmount([FromBody] UpdateAmountRequest request)
    {
        CommandResult<Unit> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok();
    }
}
