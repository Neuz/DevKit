using System;
using System.Collections.Generic;
using System.IO;
using Neuz.DevKit.Extensions;

namespace Neuz.DevKit.Result
{
    public class Error : Reason
    {
        public Exception Exception { get; set; }

        public Error(string errorMessage = null, Exception exception = null) : base(errorMessage)
        {
            if (!exception.IsNull()) Exception = exception;
        }

        public Error WithMetadata(string metaKey, object metaValue)
        {
            Metadata.Add(metaKey, metaValue);
            return this;
        }

        public Error WithMetadata(IDictionary<string, object> metadata)
        {
            foreach (var (key, value) in metadata) Metadata.Add(key, value);
            return this;
        }
    }
}