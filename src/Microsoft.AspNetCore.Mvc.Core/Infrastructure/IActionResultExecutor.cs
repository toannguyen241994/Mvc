// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    public interface IActionResultExecutor<TResult> where TResult : IActionResult
    {
        Task ExecuteAsync(ActionContext context, TResult result);
    }
}
