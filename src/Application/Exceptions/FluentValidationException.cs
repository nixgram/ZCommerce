using System;
using System.Collections.Generic;
using Domain.Common;

namespace Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public FluentValidationException(IList<ErrorDescriptor> descriptors)
        {
            ErrorDescriptors = descriptors;
        }

        public IList<ErrorDescriptor> ErrorDescriptors { get; set; }
    }
}