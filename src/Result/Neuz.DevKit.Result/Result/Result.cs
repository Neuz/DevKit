using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neuz.DevKit.Result
{
    public partial class Result
    {
        protected List<Reason> Reasons { get; } = new List<Reason>();

        public List<Error> Errors => Reasons.OfType<Error>().ToList();
        public List<Success> Successes => Reasons.OfType<Success>().ToList();

        public bool Succeed => !Reasons.OfType<Error>().Any();
    }

    public partial class Result
    {
        internal Result WithReason(Reason reason)
        {
            Reasons.Add(reason);
            return this;
        }

        internal Result WithReasons(IEnumerable<Reason> reasons)
        {
            Reasons.AddRange(reasons);
            return this;
        }

        public static Result Ok() => new Result();

        public static Result Fail(Error error) => new Result().WithReason(error);

        public static Result Fail(string errorMessage) => Fail(new Error(errorMessage));

        public static Result Try(Action action, Func<Exception, Error> exceptionHandler = null)
        {
            exceptionHandler ??= e => new Error(e.Message, e);

            try
            {
                action();
                return Ok();
            }
            catch (Exception e)
            {
                return Fail(exceptionHandler(e));
            }
        }

        public static async Task<Result> Try(Func<Task> action, Func<Exception, Error> exceptionHandler = null)
        {
            exceptionHandler ??= e => new Error(e.Message, e);

            try
            {
                await action();
                return Ok();
            }
            catch (Exception e)
            {
                return Fail(exceptionHandler(e));
            }
        }
    }
}