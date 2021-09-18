using System;

namespace Neuz.DevKit.Result
{
    public class Result<TValue> : ResultBase<Result<TValue>>
    {
        private TValue _value;

        /// <summary>
        /// Value
        /// <para>
        /// <see cref="Result.Succeed"/> 为 <c>false</c> 时，抛出异常
        /// </para>
        /// </summary>
        /// <exception cref="InvalidOperationException"> </exception>
        public TValue Value
        {
            get => Succeed ? _value : throw new InvalidOperationException("Result.Succeed is false, Value not set");
            private set => _value = value;
        }

        /// <summary>
        /// 设置Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Result<TValue> WithValue(TValue value)
        {
            Value = value;
            return this;
        }

        /// <summary>
        /// 获取Value
        /// <para>
        /// <see cref="Result.Succeed"/> 为 <c>false</c> 时，返回 default(TValue)
        /// </para>
        /// </summary>
        /// <returns></returns>
        public TValue GetValue() => Succeed ? _value : default;
    }

    public partial class Result
    {
        public static Result<TValue> Ok<TValue>() => new Result<TValue>();

        public static Result<TValue> Ok<TValue>(TValue value) => new Result<TValue>().WithValue(value);

        public static Result<TValue> Fail<TValue>(Error error) => new Result<TValue>().WithReason(error);

        public static Result<TValue> Fail<TValue>(string errorMessage) => Fail<TValue>(new Error(errorMessage));
    }
}