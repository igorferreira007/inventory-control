using FluentValidation.Results;

namespace InventoryControl.Application;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; }

    protected Result(bool isSuccess, string? message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(string message) => new(false, message ?? throw new ArgumentNullException(nameof(message)));

    public static implicit operator Result(string message) => Failure(message);
    public static implicit operator Result(ValidationResult validationResult)
    {
        return Failure(GetValidationErrors(validationResult));
    }

    protected static string GetValidationErrors(
    ValidationResult validationResult)
    {
        return string.Join(
            Environment.NewLine,
            validationResult.Errors.Select(e => e.ErrorMessage));
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T value) : base(true, null) => Value = value;
    private Result(string message) : base(false, message) { }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(string message) => new(message);
    public static implicit operator Result<T>(ValidationResult validationResult)
    {
        return new Result<T>(GetValidationErrors(validationResult));
    }
}
