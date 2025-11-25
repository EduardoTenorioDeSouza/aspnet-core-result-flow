namespace ResultFlow.Core.Common
{
    public class BusinessException : Exception
    {
        public ErrorCode Code { get; }

        public BusinessException(string message, ErrorCode code)
            : base(message)
        {
            Code = code;
        }
    }
}
