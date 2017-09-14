// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Exception thrown by <see cref="IInputFormatter"/> when the input format is not in an expected way.
    /// </summary>
    public class InputFormatException : Exception
    {
        public InputFormatException()
        {
        }

        public InputFormatException(string message)
            : base(message)
        {
        }

        public InputFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
