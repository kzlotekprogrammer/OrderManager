using System;

namespace OrderManager.Core.Domain.Identifiers;

public record WarehouseId(Guid Value)
{
    private static Guid Id = new Guid("D6FE83AC-D02B-42A7-A5E2-1D8BBE9F6F35");

    public static WarehouseId Create()
    {
        return new WarehouseId(Id);
    }
}