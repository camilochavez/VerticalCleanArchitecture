using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SLinkUser.Domain
{
    public readonly struct Result<TValue, TError>
    {
        public readonly TValue? Value;
        public readonly TError? Error;

        private Result(TValue value)
        {
            Value = value;
            Error = default;
            IsError = false;
        }

        private Result(TError error)
        {
            Value = default;
            Error = error;
            IsError = true;
        }

        public bool IsError { get; }

        public bool IsSuccess => !IsError;

        public static implicit operator Result<TValue, TError>(TValue value) => new(value);

        public static implicit operator Result<TValue, TError>(TError error) => new(error);

        public Result<TValue, TError> Match(
                Func<TValue, Result<TValue, TError>> success,
                Func<TError, Result<TValue, TError>> failure) =>
            !IsError ? success(Value!) : failure(Error!);
        public TResult Match<TResult>(
                Func<TValue, TResult> success,
                Func<TError, TResult> failure) =>
            !IsError ? success(Value!) : failure(Error!);
    }
}
