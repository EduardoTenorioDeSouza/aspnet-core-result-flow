namespace ResultFlow.Core.Common
{
    public record Result<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public string? ErrorMessage { get; init; }

        public ErrorCode? ErrorCode { get; init; }

        public static Result<T> OK(T data)
        {
            return new() { Success = true, Data = data };
        }

        public static Result<T> Fail(string message, ErrorCode code)
        {
            return new() { Success = false, ErrorMessage = message, ErrorCode = code };
        }
    }
}
