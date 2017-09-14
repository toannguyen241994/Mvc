// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Mvc.Formatters
{
    public interface IInbuiltInputFormatter
    {
        bool SendBadRequestForExceptionsDuringDeserialization { get; }
    }
}
