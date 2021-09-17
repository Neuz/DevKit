using System.Collections.Generic;

namespace Neuz.DevKit.Result
{
    public class Success : Reason
    {
        public Success(string message = null) : base(message)
        {
        }

        public Success WithMetadata(string metaKey, object metaValue)
        {
            Metadata.Add(metaKey, metaValue);
            return this;
        }

        public Success WithMetadata(IDictionary<string, object> metadata)
        {
            foreach (var (key, value) in metadata) Metadata.Add(key, value);
            return this;
        }
    }
}