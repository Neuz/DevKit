using System.Collections.Generic;
using System.Linq;

namespace Neuz.DevKit.Result
{
    public abstract class ResultBase<TResult> where TResult : ResultBase<TResult>
    {
        protected List<Reason> Reasons { get; } = new List<Reason>();

        public List<Error> Errors => Reasons.OfType<Error>().ToList();

        public List<Success> Successes => Reasons.OfType<Success>().ToList();

        public bool IsSuccess => !Reasons.OfType<Error>().Any();

        internal TResult WithReasons(IEnumerable<Reason> reasons)
        {
            Reasons.AddRange(reasons);
            return (TResult) this;
        }

        internal TResult WithReason(Reason reason)
        {
            Reasons.Add(reason);
            return (TResult) this;
        }
    }
}