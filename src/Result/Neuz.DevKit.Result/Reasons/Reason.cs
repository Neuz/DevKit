using System.Collections.Generic;
using Neuz.DevKit.Extensions;

namespace Neuz.DevKit.Result
{
    public class Reason
    {
        protected Reason(string message = null)
        {
            if (!message.IsNullOrEmpty()) Message = message;
        }

        public string Message { get; set; } = string.Empty;

        public Dictionary<string, object> Metadata { get; protected set; } = new Dictionary<string, object>();
    }
}