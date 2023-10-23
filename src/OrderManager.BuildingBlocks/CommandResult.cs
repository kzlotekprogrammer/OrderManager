namespace OrderManager.BuildingBlocks;

public record CommandResult<T>(bool IsSuccess, T? Data, string? ErrorMessage)
{
    public static CommandResult<T> Success(T data)
    {
        return new CommandResult<T>(true, data, null);
    }

    public static CommandResult<T> Failure(string errorMessage)
    {
        return new CommandResult<T>(false, default, errorMessage);
    }
}