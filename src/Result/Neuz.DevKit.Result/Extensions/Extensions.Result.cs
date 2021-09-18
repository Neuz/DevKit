using System;
using System.Collections.Generic;

namespace Neuz.DevKit.Result
{
    /// <summary>
    /// Result 扩展方法
    /// </summary>
    public static partial class Extensions
    {
        public static Result WithSuccess(this Result @this, Success success) => @this.WithReason(success);

        public static Result WithSuccess(this Result @this, Action<Success> action)
        {
            var success = new Success();
            action.Invoke(success);
            return @this.WithSuccess(success);
        }

        public static Result WithSuccesses(this Result @this, IEnumerable<Success> successes) => @this.WithReasons(successes);

        public static Result WithError(this Result @this, Error error) => @this.WithReason(error);

        public static Result WithError(this Result @this, string errorMessage, Exception exception) => @this.WithError(new Error(errorMessage, exception));

        public static Result WithError(this Result @this, Action<Error> action)
        {
            var error = new Error();
            action.Invoke(error);
            return @this.WithReason(error);
        }

        public static Result WithErrors(this Result @this, IEnumerable<Error> errors) => @this.WithReasons(errors);
    }
}