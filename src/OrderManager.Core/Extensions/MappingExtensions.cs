using OrderManager.Core.Domain.ValueObjects;
using OrderManager.Core.Dtos;

namespace OrderManager.Core.Extensions;

public static class MappingExtensions
{
    public static Address Map(this AddressDto addressDto)
    {
        return new Address
        {
            City = addressDto.City,
            Street = addressDto.Street,
            State = addressDto.State,
            ZipCode = addressDto.ZipCode
        };
    }
}
