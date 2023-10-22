using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Commands.WarehouseCommands;
using System.Threading.Tasks;
using OrderManager.API.Controllers.v1.Models;
using OrderManager.API.Controllers.v1.Extensions;

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
