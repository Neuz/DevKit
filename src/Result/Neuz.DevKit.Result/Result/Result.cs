namespace Neuz.DevKit.Result
{
    public partial class Result : ResultBase<Result>
    {
        public static Result Ok() => new Result();

        public static Result Fail(Error error) => new Result().WithReason(error);

        public static Result Fail(string errorMessage) => Fail(new Error(errorMessage));
    }
}