namespace Neuz.DevKit.Result
{
    public partial class Result<TValue> : Result
    {
        public Result()
        {
        }

        public Result(TValue value)
        {
            _value = value;
        }

        private TValue _value;

        public TValue Value
        {
            get => Succeed ? _value : default;
            private set => _value = value;
        }

        public Result<TValue> WithValue(TValue value)
        {
            Value = value;
            return this;
        }
    }
}