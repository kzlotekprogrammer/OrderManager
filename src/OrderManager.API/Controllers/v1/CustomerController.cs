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
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        CommandResult<Guid> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest();

        return Ok(result.Data);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateDetails([FromBody] UpdateDetailsRequest request)
    {
        CommandResult<Unit> result = await _mediator.Send(request.Map());

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok();
    }
}
