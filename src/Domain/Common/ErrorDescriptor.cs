using System;

namespace Domain.Common
{
    /// <summary>
    /// If someone want to describe the cause of error to end user
    /// Use this class with one of function return type
    /// </summary>
    public class ErrorDescriptor
    {
        public string CauseOfError { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExtraNoteForResolve { get; set; }
    }
}