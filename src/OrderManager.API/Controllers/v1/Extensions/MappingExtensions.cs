using OrderManager.API.Controllers.v1.Models;
using OrderManager.Core.Commands.CustomerCommands;
using OrderManager.Core.Commands.OrderCommands;
using OrderManager.Core.Commands.WarehouseCommands;
using OrderManager.Core.Dtos;

namespace OrderManager.API.Controllers.v1.Extensions;

public static class MappingExtensions
{
    public static CreateCustomerCommand Map(this CreateCustomerRequest request)
    {
        return new CreateCustomerCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address.Map(),
        };
    }

    public static UpdateDetailsCommand Map(this UpdateDetailsRequest request)
    {
        return new UpdateDetailsCommand
        {
            CustomerId = request.CustomerId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address.Map(),
        };
    }

    public static AddressDto Map(this Address request)
    {
        return new AddressDto
        {
            City = request.City,
            Street = request.Street,
            PostalCode = request.PostalCode,
            PostOffice = request.PostOffice,
        };
    }

    public static CreateOrderCommand Map(this CreateOrderRequest request)
    {
        return new CreateOrderCommand
        {
            CustomerId = request.CustomerId,
        };
    }

    public static AddOrderItemCommand Map(this AddOrderItemRequest request)
    {
        return new AddOrderItemCommand
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
        };
    }

    public static AddProductCommand Map(this AddProductRequest request)
    {
        return new AddProductCommand
        {
            Name = request.Name,
            Price = request.Price,
            Amount = request.Amount,
        };
    }

    public static UpdateAmountCommand Map(this UpdateAmountRequest request)
    {
        return new UpdateAmountCommand
        {
            ProductId = request.ProductId,
            Amount = request.Amount,
        };
    }
}
