using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderManager.API.Controllers;

[ApiController]
[Route("api/error")]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger) 
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public IActionResult Error()
    {
        IExceptionHandlerFeature? exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        Exception? exception = exceptionFeature?.Error;

        if (exception is not null)
            _logger.LogError(exception, "An exception occurred.");

        return Problem("An exception occurred.");
    }
}