using System;
using System.Collections.Generic;

namespace Neuz.DevKit.Result
{
    public static partial class Extensions
    {
        public static Result<TValue> WithSuccess<TValue>(this Result<TValue> @this, Success success) => @this.WithReason(success);

        public static Result<TValue> WithSuccess<TValue>(this Result<TValue> @this, Action<Success> action)
        {
            var success = new Success();
            action.Invoke(success);
            return @this.WithSuccess(success);
        }

        public static Result<TValue> WithSuccesses<TValue>(this Result<TValue> @this, IEnumerable<Success> successes) => @this.WithReasons(successes);

        public static Result<TValue> WithError<TValue>(this Result<TValue> @this, Error error) => @this.WithReason(error);

        public static Result<TValue> WithError<TValue>(this Result<TValue> @this, string errorMessage, Exception exception) => @this.WithError(new Error(errorMessage, exception));

        public static Result<TValue> WithError<TValue>(this Result<TValue> @this, Action<Error> action)
        {
            var error = new Error();
            action.Invoke(error);
            return @this.WithReason(error);
        }

        public static Result<TValue> WithErrors<TValue>(this Result<TValue> @this, IEnumerable<Error> errors) => @this.WithReasons(errors);
    }
}